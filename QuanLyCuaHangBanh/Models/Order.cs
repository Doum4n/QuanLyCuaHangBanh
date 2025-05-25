using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty; // e.g., Cash, Credit Card, etc.
        public string Status { get; set; } // e.g., Pending, Completed, Cancelled
        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order_Detail> OrderDetails { get; set; } // Assuming one-to-one relationship for simplicity
    }
}
