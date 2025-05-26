using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class SupplierDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public decimal TotalAccountPayable { get; set; } // Tổng công nợ phải trả cho nhà cung cấp
        //public SupplierDTO(int id, string name, string address, string email, string description, decimal totalAccountPaysable)
        //{
        //    ID = id;
        //    Name = name;
        //    Address = address;
        //    Email = email;
        //    Description = description;
        //    TotalAccountPayable = totalAccountPaysable;
        //}
    }
}
