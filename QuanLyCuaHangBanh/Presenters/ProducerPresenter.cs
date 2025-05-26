using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.Suplier;

namespace QuanLyCuaHangBanh.Presenters
{
    class ProducerPresenter
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private ISuplierView view;
        private ProducerRepo repo;

        private BindingSource bindingSource;

        public ProducerPresenter(ISuplierView view)
        {
            this.view = view;
            repo = new ProducerRepo(context);
            this.view.SearchEvent += OnSearch;
            this.view.DeleteEvent += OnDelete;
            this.view.AddNewEvent += OnAddNew;
            this.view.EditEvent += OnEdit;

            bindingSource = new BindingSource();
            this.view.SetBindingSource(bindingSource);

            loadData();
        }

        private void loadData()
        {
            bindingSource.DataSource = repo.GetAllAsDto<SupplierDTO>(
                o => new SupplierDTO
                {
                    ID = o.ID,
                    Name = o.Name,
                    PhoneNumber = o.PhoneNumber,
                    Email = o.Email,
                    Address = o.Address,
                    Description = o.Description,
                    TotalAccountPayable = o.AccountsPayables.Sum(a => a.Amount) // Tính tổng công nợ phải trả
                }
            );
        }


        private void OnEdit(object? sender, EventArgs e)
        {
            SuplierInputView producerInputView = new SuplierInputView((SupplierDTO)this.view.SelectedItem);
            if (producerInputView.ShowDialog() == DialogResult.OK)
            {
                
                if (producerInputView.Tag is Supplier producer)
                {
                    producer.ID = ((Supplier)this.view.SelectedItem).ID;
                    repo.Update(producer);
                    loadData();
                }
            }
        }

        private void OnAddNew(object? sender, EventArgs e)
        {
            SuplierInputView producerInputView = new SuplierInputView();
            if (producerInputView.ShowDialog() == DialogResult.OK)
            {
                if (producerInputView.Tag is Supplier producer)
                {
                    repo.Add(producer);
                    loadData();
                }
            }
        }

        private void OnDelete(object? sender, EventArgs e)
        {
            repo.Delete((Supplier)this.view.SelectedItem);
            loadData();
        }

        private void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = this.view.SearchValue.ToLower();  // Chuyển đổi sang chữ thường để tìm kiếm không phân biệt chữ hoa/thường

            bindingSource.DataSource = repo.GetAll().Where(
                p => p.Name.ToLower().Contains(searchValue) ||
                     p.PhoneNumber.Contains(searchValue) ||
                     p.Address.ToLower().Contains(searchValue) ||
                     p.Email.ToLower().Contains(searchValue) ||
                     p.Address.ToLower().Contains(searchValue)
                ).ToList();
        }
    }
}
