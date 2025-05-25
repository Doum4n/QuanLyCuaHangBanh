using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Order_Detail
    {
        public int ID { get; set; }
        public int OrderId { get; set; } // Foreign key to Order
        public int Product_UnitID { get; set; } // Foreign key to ProductUnit
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Price at the time of order
        public string Note { get; set; } = string.Empty; // Additional notes for the order detail
        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Product_Unit Product_Unit { get; set; }

    }
}
