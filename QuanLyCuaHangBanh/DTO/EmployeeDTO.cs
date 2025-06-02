using System.ComponentModel;
using System.Diagnostics;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.DTO
{
    public class EmployeeDTO : ISearchable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        [Browsable(false)]
        public string Password { get; set; }

        public bool MatchesSearch(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue)) return true;
            searchValue = searchValue.ToLower();
            return Name.ToLower().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   PhoneNumber.ToLower().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Address.ToLower().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Role.ToLower().Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }

        public Employee ToEntity()
        {
            return new Employee
            {
                ID = ID,
                Name = Name,
                PhoneNumber = PhoneNumber,
                Address = Address,
                Role = Role,
                Username = Username,
                Password = Password
            };
        }
    }
}