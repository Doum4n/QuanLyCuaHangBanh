using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.Category;

namespace QuanLyCuaHangBanh.Presenters
{
    class CategoryPresenter : PresenterBase<Category>
    {
        public CategoryPresenter(ICategoryView view, IRepositoryProvider provider) : base(view, provider)
        {
            view.ImportEvent += OnImport;
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            Category selectedCategory = (Category)View.SelectedItem;
            CategoryInputView categoryInputView = new CategoryInputView((Category)View.SelectedItem);

            if (categoryInputView.ShowDialog() == DialogResult.OK)
            {
                if (categoryInputView.Tag is (string categoryName, string description))
                {
                    Category category = new Category(selectedCategory.ID, categoryName, description);
                    Provider.GetRepository<Category>().Update(category);
                    LoadData();
                }
            }
        }

        public override void OnExport(object? sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên loại", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));

            foreach (var item in Provider.GetRepository<Category>().GetAll())
            {
                dataTable.Rows.Add(item.ID, item.Name, item.Description);
            }

            ExcelHandler.ExportExcel("Loại sản phẩm", "Loại sản phẩm", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel((DataRow row) =>
            {
                // Assuming the first column is ID, second is Name, third is Description
                //int id = Convert.ToInt32(row[0]);
                string name = row[0].ToString();
                string description = row[1].ToString();
                Category category = new Category( name, description);
                Provider.GetRepository<Category>().Add(category);
                View.Message = "Import thành công!";
            });
            LoadData();
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            CategoryInputView categoryInputView = new CategoryInputView();
            if (categoryInputView.ShowDialog() == DialogResult.OK)
            {
                if (categoryInputView.Tag is (string categoryName, string description))
                {
                    Provider.GetRepository<Category>().Add(new Category
                    (
                        categoryName,
                        description
                    ));
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            Provider.GetRepository<Category>().Delete((Category)View.SelectedItem);
            LoadData();
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            // Lọc danh sách theo tên Category
            string searchValue = View.SearchValue.ToLower();  // Chuyển đổi sang chữ thường để tìm kiếm không phân biệt chữ hoa/thường
            BindingSource.DataSource = Provider.GetRepository<Category>().GetAll()
                .Where(category => category.Name.ToLower().Contains(searchValue))  // Lọc theo tên Category
                .ToList();  // Chuyển thành danh sách để BindingSource có thể áp dụng

        }


        public override void LoadData()
        {
            // Lấy danh sách Category từ repository và gán vào BindingSource
            BindingSource.DataSource = Provider.GetRepository<Category>().GetAll().ToList();
            View.SetBindingSource(BindingSource);
        }
    }
}
