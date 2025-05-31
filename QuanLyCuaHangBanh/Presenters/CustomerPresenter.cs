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
    class CustomerPresenter(ICustomerView view, CustomerService customerService) : PresenterBase<Customer>(view, (IService)customerService)
    {
        private IList<CustomerDTO> customers = new List<CustomerDTO>();
        public override async Task InitializeAsync()
        {
            customers = await ((CustomerService)Service).GetAllCustomers();
            BindingSource.DataSource = customers;
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            if(BindingSource.List is IList<CustomerDTO> customerDTOs)
            {
                DataTable dataTable = ((CustomerService)Service).ExportCustomersToDataTable(customerDTOs);
                ExcelHandler.ExportExcel("Khách hàng", "Khách hàng", dataTable);
            }
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(((CustomerService)Service).ImportCustomerFromDataRow);
            InitializeAsync(); // Load lại dữ liệu sau khi import
        }

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
                             updatedCustomer.ID = ((Customer)this.View.SelectedItem).ID; // ID đã được gán qua constructor của inputView
                            ((CustomerService)Service).UpdateCustomer(updatedCustomer);
                            ShowMessage("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxIcon.Information);
                            InitializeAsync();
                        }
                        catch (Exception ex)
                        {
                            View.Message = ex.Message;
                            return;
                        }
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một khách hàng để chỉnh sửa.";
            }
        }

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
                        return;
                    }
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is CustomerDTO customerToDelete)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((CustomerService)Service).DeleteCustomer(customerToDelete.ToEntity());
                    View.Message = "Xóa khách hàng thành công!";
                    InitializeAsync(); // Load lại dữ liệu sau khi xóa
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một khách hàng để xóa.";
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(View.SearchValue))
            {
                InitializeAsync(); // Load lại tất cả dữ liệu nếu trường tìm kiếm trống
            }
            else
            {
                if(customers.Count > 0)
                {
                    var filteredCustomers = customers.Where(c => c.MatchesSearch(View.SearchValue)).ToList();
                    BindingSource.DataSource = filteredCustomers;
                }
            }
        }
    }
}