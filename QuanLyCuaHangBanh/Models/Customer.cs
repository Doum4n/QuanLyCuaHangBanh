using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Type { get; set; } // Loại khách hàng
        public string? Email { get; set; }
        public decimal Limit { get; set; }
        public int CreditPeriod { get; set; }

        public virtual ICollection<AccountsReceivable> AccountsReceivables { get; set; } = new List<AccountsReceivable>();
    }
}
