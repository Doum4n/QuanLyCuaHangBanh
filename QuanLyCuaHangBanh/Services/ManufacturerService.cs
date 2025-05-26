using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLyCuaHangBanh.Services
{
    public class ManufacturerService(IRepositoryProvider provider) : IService
    {
        private readonly IRepositoryProvider _provider = provider;

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return _provider.GetRepository<Manufacturer>().GetAll();
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            _provider.GetRepository<Manufacturer>().Add(manufacturer);
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _provider.GetRepository<Manufacturer>().Update(manufacturer);
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _provider.GetRepository<Manufacturer>().Delete(manufacturer);
        }

        public IEnumerable<Manufacturer> SearchManufacturers(string searchValue)
        {
            var searchText = searchValue.Trim().ToLower();
            return _provider.GetRepository<Manufacturer>()
                .GetAll()
                .Where(m => m.Name.ToLower().Contains(searchText) || m.Description.ToLower().Contains(searchText))
                .ToList();
        }

        public DataTable ExportManufacturersToDataTable(IEnumerable<Manufacturer> manufacturers)
        {
            DataTable dataTable = new DataTable("Manufacturers");
            dataTable.Columns.Add("Mã nhà cung cấp", typeof(int));
            dataTable.Columns.Add("Nhà cung cấp", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));

            foreach (var manufacturer in manufacturers)
            {
                dataTable.Rows.Add(manufacturer.ID, manufacturer.Name, manufacturer.Description);
            }
            return dataTable;
        }

        public void ImportManufacturerFromDataRow(DataRow row)
        {
            var manufacturer = new Manufacturer
            {
                //ID = Convert.ToInt32(row["Mã nhà cung cấp"]), // Thường ID sẽ được tự động tạo khi thêm mới
                Name = row["Nhà cung cấp"].ToString() ?? string.Empty,
                Description = row["Mô tả"].ToString() ?? string.Empty
            };
            _provider.GetRepository<Manufacturer>().Add(manufacturer);
        }
    }
}