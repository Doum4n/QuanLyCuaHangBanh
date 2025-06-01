using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Services; // Thêm namespace của Service
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.DTO; // Để sử dụng DialogResult và MessageBox

namespace QuanLyCuaHangBanh.Presenters
{
    /// <summary>
    /// Presenter xử lý logic cho màn hình quản lý khách hàng
    /// </summary>
    /// <param name="view">View hiển thị giao diện khách hàng</param>
    /// <param name="customerService">Service xử lý nghiệp vụ khách hàng</param>
    class CustomerPresenter(ICustomerView view, CustomerService customerService) : PresenterBase<Customer>(view, (IService)customerService)
    {
        #region Fields

        /// <summary>
        /// Danh sách khách hàng dưới dạng DTO
        /// </summary>
        private IList<CustomerDTO> customers = new List<CustomerDTO>();

        #endregion

        #region Override Methods

        /// <summary>
        /// Khởi tạo dữ liệu ban đầu cho màn hình
        /// </summary>
        public override async Task InitializeAsync()
        {
            customers = await ((CustomerService)Service).GetAllCustomers();
            BindingSource.DataSource = customers;
        }

        /// <summary>
        /// Xuất dữ liệu khách hàng ra Excel
        /// </summary>
        /// <param name="sender">Nút xuất Excel</param>
        /// <param name="e">Event arguments</param>
        public override void OnExport(object? sender, EventArgs e)
        {
            if(BindingSource.List is IList<CustomerDTO> customerDTOs)
            {
                DataTable dataTable = ((CustomerService)Service).ExportCustomersToDataTable(customerDTOs);
                ExcelHandler.ExportExcel("Khách hàng", "Khách hàng", dataTable);
            }
        }

        /// <summary>
        /// Nhập dữ liệu khách hàng từ Excel
        /// </summary>
        /// <param name="sender">Nút nhập Excel</param>
        /// <param name="e">Event arguments</param>
        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(((CustomerService)Service).ImportCustomerFromDataRow);
            InitializeAsync(); // Load lại dữ liệu sau khi import
        }

        /// <summary>
        /// Chỉnh sửa thông tin khách hàng
        /// </summary>
        /// <param name="sender">Nút chỉnh sửa</param>
        /// <param name="e">Event arguments</param>
        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is CustomerDTO selectedCustomer)
            {
                CustomerInputView customerInputView = new CustomerInputView(selectedCustomer.ToEntity());
                if (customerInputView.ShowDialog() == DialogResult.OK)
                {
                    if (customerInputView.Tag is Customer updatedCustomer)
                    {
                        try
                        {
                            updatedCustomer.ID = selectedCustomer.ID;
                            ((CustomerService)Service).UpdateCustomer(updatedCustomer);
                            ShowMessage("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxIcon.Information);
                            InitializeAsync();
                        }
                        catch (Exception ex)
                        {
                            View.Message = ex.Message;
                        }
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một khách hàng để chỉnh sửa.";
            }
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        /// <param name="sender">Nút thêm mới</param>
        /// <param name="e">Event arguments</param>
        public override void OnAddNew(object? sender, EventArgs e)
        {
            CustomerInputView customerInputView = new CustomerInputView();
            if (customerInputView.ShowDialog() == DialogResult.OK)
            {
                if (customerInputView.Tag is Customer customer)
                {
                    try
                    {
                        ((CustomerService)Service).AddCustomer(customer);
                        ShowMessage("Thêm khách hàng thành công!", "Thông báo", MessageBoxIcon.Information);
                        InitializeAsync();
                    }
                    catch (Exception ex)
                    {
                        View.Message = ex.Message;
                    }
                }
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="sender">Nút xóa</param>
        /// <param name="e">Event arguments</param>
        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is CustomerDTO customerToDelete)
            {
                if (ShowConfirmationDialog("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa"))
                {
                    try
                    {
                        ((CustomerService)Service).DeleteCustomer(customerToDelete.ToEntity());
                        ShowMessage("Xóa khách hàng thành công!", "Thông báo", MessageBoxIcon.Information);
                        InitializeAsync();
                    }
                    catch (Exception ex)
                    {
                        View.Message = ex.Message;
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một khách hàng để xóa.";
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng theo từ khóa
        /// </summary>
        /// <param name="sender">Nút tìm kiếm</param>
        /// <param name="e">Event arguments</param>
        public override void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = View.SearchValue;
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                InitializeAsync(); // Load lại tất cả dữ liệu nếu trường tìm kiếm trống
            }
            else
            {
                if (customers.Count > 0)
                {
                    var filteredCustomers = customers.Where(c => c.MatchesSearch(searchValue)).ToList();
                    BindingSource.DataSource = filteredCustomers;
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Hiển thị thông báo cho người dùng
        /// </summary>
        /// <param name="message">Nội dung thông báo</param>
        /// <param name="title">Tiêu đề thông báo</param>
        /// <param name="icon">Icon hiển thị</param>
        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Hiển thị hộp thoại xác nhận
        /// </summary>
        /// <param name="message">Nội dung cần xác nhận</param>
        /// <param name="title">Tiêu đề hộp thoại</param>
        /// <returns>True nếu người dùng đồng ý, False nếu không</returns>
        private bool ShowConfirmationDialog(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #endregion
    }
}