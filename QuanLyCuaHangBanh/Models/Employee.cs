using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Password for login

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Position { get; set; } // e.g., Manager, Cashier, etc.

        public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    }
}
