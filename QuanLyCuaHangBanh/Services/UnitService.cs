using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms.Design;

namespace QuanLyCuaHangBanh.Services
{
    public class UnitService(IRepositoryProvider provider) : IService
    {
        private readonly IRepositoryProvider _provider = provider;

        public IEnumerable<Unit> GetAllUnits()
        {
            return _provider.GetRepository<Unit>().GetAll();
        }

        public void AddUnit(Unit unit)
        {
            _provider.GetRepository<Unit>().Add(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            _provider.GetRepository<Unit>().Update(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            _provider.GetRepository<Unit>().Delete(unit);
        }

        public IEnumerable<Unit> SearchUnits(string searchValue)
        {
            return _provider.GetRepository<Unit>()
                .GetAll()
                .Where(u => u.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                            u.Description.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public DataTable ExportUnitsToDataTable(IEnumerable<Unit> units)
        {
            DataTable dataTable = new DataTable("Units");
            dataTable.Columns.Add("Mã ĐVT", typeof(int));
            dataTable.Columns.Add("ĐVT", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));

            foreach (var unit in units)
            {
                dataTable.Rows.Add(unit.ID, unit.Name, unit.Description);
            }
            return dataTable;
        }

        public void ImportUnitFromDataRow(DataRow row)
        {
            if (row.ItemArray.Length >= 3)
            {
                Unit unit = new Unit
                {
                    //ID = Convert.ToInt32(row[0]), // Không gán ID khi thêm mới, thường ID sẽ tự động tăng
                    Name = row[1].ToString() ?? string.Empty,
                    Description = row[2].ToString() ?? string.Empty
                };
                _provider.GetRepository<Unit>().Add(unit);
            }
        }
    }
}