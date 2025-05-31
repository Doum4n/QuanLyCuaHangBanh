using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks; // Để sử dụng .ToList()

namespace QuanLyCuaHangBanh.Services
{
    public class EmployeeService(IRepositoryProvider provider) : IService
    {
        private readonly IRepositoryProvider _provider = provider;

        public async Task<IList<EmployeeDTO>> GetAllEmployees()
        {
            return await _provider.GetRepository<Employee>().GetAllAsDto(
                o => new EmployeeDTO
                {
                    ID = o.ID,
                    Name = o.Name,
                    PhoneNumber = o.PhoneNumber,
                    Address = o.Address,
                    Role = o.Role,
                    Username = o.Username,
                    Password = o.Password
                });
        }

        public void AddEmployee(Employee employee)
        {
            _provider.GetRepository<Employee>().Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _provider.GetRepository<Employee>().Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _provider.GetRepository<Employee>().Delete(employee);
        }

        public async Task ExportEmployees(IList<Employee> employees)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Mã nhân viên");
            dataTable.Columns.Add("Tên nhân viên");
            dataTable.Columns.Add("Số điện thoại");
            dataTable.Columns.Add("Địa chỉ");
            dataTable.Columns.Add("Chức vụ");
            foreach (var employee in employees)
            {
                dataTable.Rows.Add(employee.ID, employee.Name, employee.PhoneNumber, employee.Address, employee.Role);
            }
            ExcelHandler.ExportExcel("Nhân viên", "Nhân viên", dataTable);
        }

        public void ImportEmployees()
        {
            ExcelHandler.ImportExcel(ImportEmployee);
        }

        public void ImportEmployee(DataRow row)
        {
            var employee = new Employee(){
                Name = row["Tên nhân viên"].ToString() ?? string.Empty,
                PhoneNumber = row["Số điện thoại"].ToString() ?? string.Empty,
                Address = row["Địa chỉ"].ToString() ?? string.Empty,
                Role = row["Chức vụ"].ToString() ?? string.Empty
            };
            _provider.GetRepository<Employee>().Add(employee);
        }
    }
}