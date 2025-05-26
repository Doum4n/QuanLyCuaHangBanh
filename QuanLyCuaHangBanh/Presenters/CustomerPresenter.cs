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
using QuanLyCuaHangBanh.Views; // Để sử dụng DialogResult và MessageBox

namespace QuanLyCuaHangBanh.Presenters
{
    class CustomerPresenter : PresenterBase<Customer>
    {
        public CustomerPresenter(ICustomerView view, CustomerService customerService)
            : base(view, (IService)customerService) // Truyền service vào PresenterBase
        {
        }

        public override void LoadData()
        {
            BindingSource.DataSource = ((CustomerService)Service).GetAllCustomers();
            // View.SetBindingSource(BindingSource); // Dòng này có thể không cần thiết nếu đã được gọi trong PresenterBase
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((CustomerService)Service).ExportCustomersToDataTable((IEnumerable<Customer>)BindingSource.List);
            ExcelHandler.ExportExcel("Khách hàng", "Khách hàng", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(((CustomerService)Service).ImportCustomerFromDataRow);
            View.Message = "Import thành công!";
            LoadData(); // Load lại dữ liệu sau khi import
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Customer selectedCustomer)
            {
                CustomerInputView customerInputView = new CustomerInputView(selectedCustomer);
                if (customerInputView.ShowDialog() == DialogResult.OK)
                {
                    if (customerInputView.Tag is Customer updatedCustomer)
                    {
                        try
                        {
                            // updatedCustomer.ID = ((Customer)this.View.SelectedItem).ID; // ID đã được gán qua constructor của inputView
                            ((CustomerService)Service).UpdateCustomer(updatedCustomer);
                            View.Message = "Cập nhật khách hàng thành công!";
                            LoadData();
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
                        View.Message = "Thêm khách hàng thành công!";
                        LoadData();
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
            if (View.SelectedItem is Customer customerToDelete)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((CustomerService)Service).DeleteCustomer(customerToDelete);
                    View.Message = "Xóa khách hàng thành công!";
                    LoadData(); // Load lại dữ liệu sau khi xóa
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
                LoadData(); // Load lại tất cả dữ liệu nếu trường tìm kiếm trống
            }
            else
            {
                BindingSource.DataSource = ((CustomerService)Service).SearchCustomers(View.SearchValue);
            }
        }
    }
}