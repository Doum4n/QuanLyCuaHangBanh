using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;

namespace QuanLyCuaHangBanh.Presenters
{
    class ProducerPresenter
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private IProducerView view;
        private ProducerRepo repo;

        private BindingSource bindingSource;

        public ProducerPresenter(IProducerView view)
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
            bindingSource.DataSource = repo.GetAll();
        }


        private void OnEdit(object? sender, EventArgs e)
        {
            ProducerInputView producerInputView = new ProducerInputView((Producer)this.view.SelectedItem);
            if (producerInputView.ShowDialog() == DialogResult.OK)
            {
                
                if (producerInputView.Tag is Producer producer)
                {
                    producer.ID = ((Producer)this.view.SelectedItem).ID;
                    repo.Update(producer);
                    loadData();
                }
            }
        }

        private void OnAddNew(object? sender, EventArgs e)
        {
            ProducerInputView producerInputView = new ProducerInputView();
            if (producerInputView.ShowDialog() == DialogResult.OK)
            {
                if (producerInputView.Tag is Producer producer)
                {
                    repo.Add(producer);
                    loadData();
                }
            }
        }

        private void OnDelete(object? sender, EventArgs e)
        {
            repo.Delete((Producer)this.view.SelectedItem);
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
