using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.DTO
{
    public class CustomerDTO : ISearchable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public decimal TotalAccountPayable { get; set; }
        public decimal Limit { get; set; }
        public bool MatchesSearch(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue)) return true;
            searchValue = searchValue.ToLower();
            return Name.ToLower().Contains(searchValue) ||
                   PhoneNumber.ToLower().Contains(searchValue) ||
                   Address.ToLower().Contains(searchValue) ||
                   Email.ToLower().Contains(searchValue) ||
                   Type.ToLower().Contains(searchValue); 
        }

        public Customer ToEntity()
        {
            return new Customer
            {
                ID = ID,
                Name = Name,
                PhoneNumber = PhoneNumber,
                Address = Address,
                Email = Email,
                Type = Type,
                Limit = Limit,
            };
        }
    }
}