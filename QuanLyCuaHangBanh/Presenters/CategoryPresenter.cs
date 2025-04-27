using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;

namespace QuanLyCuaHangBanh.Presenters
{
    class CategoryPresenter
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();

        private ICategoryView view;
        private CategoryRepo repo;
        private BindingSource bindingSource;

        public CategoryPresenter(ICategoryView view)
        {
            this.view = view;
            this.repo = new CategoryRepo(context);

            this.view.SearchEvent += OnSearch;
            this.view.DeleteEvent += OnDelete;
            this.view.AddNewEvent += OnAddNew;
            this.view.EditEvent += OnEdit;
            this.bindingSource = new BindingSource();
            this.view.SetBindingSource(bindingSource);

            loadDate();
        }

        private void OnEdit(object? sender, EventArgs e)
        {
            Category selectedCategory = (Category)this.view.SelectedItem;
            CategoryInputView categoryInputView = new CategoryInputView((Category)this.view.SelectedItem);

            if (categoryInputView.ShowDialog() == DialogResult.OK)
            {
                if (categoryInputView.Tag is (string categoryName, string description))
                {
                    Category category = new Category(selectedCategory.ID, categoryName, description);
                    repo.Update(category);
                    loadDate();
                }
            }
        }

        private void OnAddNew(object? sender, EventArgs e)
        {
            CategoryInputView categoryInputView = new CategoryInputView();
            if (categoryInputView.ShowDialog() == DialogResult.OK)
            {
                if (categoryInputView.Tag is (string categoryName, string description))
                {
                    repo.Add(new Category
                    (
                        categoryName,
                        description
                    ));
                    loadDate();
                }
            }
        }

        private void OnDelete(object? sender, EventArgs e)
        {
            repo.Delete((Category)this.view.SelectedItem);
            loadDate();
        }

        private void OnSearch(object? sender, EventArgs e)
        {
            // Lọc danh sách theo tên Category
            string searchValue = this.view.SearchValue.ToLower();  // Chuyển đổi sang chữ thường để tìm kiếm không phân biệt chữ hoa/thường
            bindingSource.DataSource = repo.GetAll()
                .Where(category => category.Name.ToLower().Contains(searchValue))  // Lọc theo tên Category
                .ToList();  // Chuyển thành danh sách để BindingSource có thể áp dụng

        }


        private void loadDate()
        {
            bindingSource.DataSource = repo.GetAll();
        }
    }
}
