using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System.Collections.Generic;
using System.Linq; // Để sử dụng .ToList()

namespace QuanLyCuaHangBanh.Services
{
    public class EmployeeService(IRepositoryProvider provider) : IService
    {
        private readonly IRepositoryProvider _provider = provider;

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _provider.GetRepository<Employee>().GetAll();
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

        // Bạn có thể thêm các phương thức Export/Import/Search ở đây nếu cần, ví dụ:
        // public void ExportEmployeesToExcel() { ... }
        // public void ImportEmployeesFromExcel() { ... }
        // public IEnumerable<Employee> SearchEmployees(string searchValue) { ... }
    }
}