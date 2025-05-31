using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design; // Không cần thiết nếu không dùng
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Thêm để sử dụng DialogResult và MessageBox

using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data; // Có thể không cần nếu IRepositoryProvider không cần
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories; // Có thể không cần nếu chỉ dùng qua service
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views; // Có thể không cần nếu ICategoryView đủ
using QuanLyCuaHangBanh.Views.Category;
using QuanLyCuaHangBanh.Services; // Thêm namespace của Service

namespace QuanLyCuaHangBanh.Presenters
{
    class CategoryPresenter(ICategoryView view, CategoryService categoryService) : PresenterBase<Category>(view, (IService)categoryService)
    {
        public override async Task InitializeAsync()
        {
            BindingSource.DataSource = await ((CategoryService)Service).GetAllCategories();
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Category selectedCategory)
            {
                CategoryInputView categoryInputView = new CategoryInputView(selectedCategory);

                if (categoryInputView.ShowDialog() == DialogResult.OK)
                {
                    if (categoryInputView.Tag is (string categoryName, string description))
                    {
                        Category category = new Category(selectedCategory.ID, categoryName, description);
                        ((CategoryService)Service).UpdateCategory(category);
                        View.Message = "Cập nhật danh mục thành công!";
                        InitializeAsync();
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một danh mục để chỉnh sửa.";
            }
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((CategoryService)Service).ExportCategoriesToDataTable((IEnumerable<Category>)BindingSource.List);
            ExcelHandler.ExportExcel("Loại sản phẩm", "Loại sản phẩm", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(((CategoryService)Service).ImportCategoryFromDataRow);
            View.Message = "Import thành công!";
            InitializeAsync(); // Load lại dữ liệu sau khi import
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            CategoryInputView categoryInputView = new CategoryInputView();
            if (categoryInputView.ShowDialog() == DialogResult.OK)
            {
                if (categoryInputView.Tag is (string categoryName, string description))
                {
                    Category newCategory = new Category(categoryName, description);
                    ((CategoryService)Service).AddCategory(newCategory);
                    View.Message = "Thêm danh mục thành công!";
                    InitializeAsync();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Category categoryToDelete)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((CategoryService)Service).DeleteCategory(categoryToDelete);
                    View.Message = "Xóa danh mục thành công!";
                    InitializeAsync(); // Load lại dữ liệu sau khi xóa
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một danh mục để xóa.";
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
                BindingSource.DataSource = ((CategoryService)Service).SearchCategories(View.SearchValue);
            }
        }
    }
}