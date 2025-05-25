using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    class CustomerPresenter(ICustomerView view, IRepositoryProvider repository) : PresenterBase<Customer>(view, repository)
    {
        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            dataTable.Columns.Add("Số điện thoại", typeof(string));
            dataTable.Columns.Add("Địa chỉ", typeof(string));
            foreach (var item in Provider.GetRepository<Customer>().GetAll())
            {
                dataTable.Rows.Add(item.ID, item.Name, item.PhoneNumber, item.Address);
            }
            ExcelHandler.ExportExcel("Khách hàng", "Khách hàng", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel((DataRow row) =>
            {
                Customer customer = new Customer()
                {
                    //ID = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    PhoneNumber = row[2].ToString(),
                    Address = row[3].ToString()
                };
                Provider.GetRepository<Customer>().Add(customer);
                View.Message = "Import thành công!";
            });
            LoadData();
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            CustomerInputView customerInputView = new CustomerInputView((Customer)(this.View.SelectedItem));
            if (customerInputView.ShowDialog() == DialogResult.OK)
            {
                if (customerInputView.Tag is Customer updatedCustomer)
                {
                    try
                    {
                        this.View.Message = "Thêm khách hàng thành công";
                        updatedCustomer.ID = ((Customer)this.View.SelectedItem).ID;
                        Provider.GetRepository<Customer>().Update(updatedCustomer);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        this.View.Message = ex.Message;
                        return;
                    }
                }
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
                        Provider.GetRepository<Customer>().Add(customer);
                        this.View.Message = "Thêm khách hàng thành công";
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        this.View.Message = ex.Message;
                        return;
                    }
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            Provider.GetRepository<Customer>().Delete((Customer)this.View.SelectedItem);
            this.View.Message = "Xóa khách hàng thành công";
            LoadData();
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
