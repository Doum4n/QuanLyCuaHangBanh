using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Services
{
    public class CategoryService(IRepositoryProvider provider) : IService
    {

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await provider.GetRepository<Category>().GetAll();
        }

        public void AddCategory(Category category)
        {
            provider.GetRepository<Category>().Add(category);
        }

        public void UpdateCategory(Category category)
        {
            provider.GetRepository<Category>().Update(category);
        }

        public void DeleteCategory(Category category)
        {
            provider.GetRepository<Category>().Delete(category);
        }

        public DataTable ExportCategoriesToDataTable(IEnumerable<Category> categories)
        {
            DataTable dataTable = new DataTable("Categories");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên loại", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));

            foreach (var item in categories)
            {
                dataTable.Rows.Add(item.ID, item.Name, item.Description);
            }
            return dataTable;
        }

        public void ImportCategoryFromDataRow(DataRow row)
        {
            // Giả định cột đầu tiên là Tên, cột thứ hai là Mô tả
            string name = row[0].ToString() ?? string.Empty;
            string description = row[1].ToString() ?? string.Empty;
            Category category = new Category(name, description);
            provider.GetRepository<Category>().Add(category);
        }

        public async Task<IEnumerable<Category>> SearchCategories(string searchValue)
        {
            string searchLower = searchValue.ToLower();

            IList<Category> allCategories = await provider.GetRepository<Category>().GetAll();

            return allCategories
                .Where(category => category.Name.ToLower().Contains(searchLower))
                .ToList();
        }
    }
}