using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;

namespace QuanLyCuaHangBanh.Presenters
{
    class CustomerPresenter(IView view, IRepository<Customer> repository) : PresenterBase<Customer>(view, repository)
    {
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
                        Repository.Update(updatedCustomer);
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
                        Repository.Add(customer);
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
            Repository.Delete((Customer)this.View.SelectedItem);
            this.View.Message = "Xóa khách hàng thành công";
            LoadData();
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
