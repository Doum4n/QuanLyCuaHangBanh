using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public int ProductID { get; set; } // Foreign key to the Product table
        public int UnitID { get; set; } // Foreign key to the Unit table
        public int Quantity { get; set; } // Quantity of the product in stock
        public DateTime LastUpdated { get; set; } // Date and time of the last update
        public string Note { get; set; } // Additional notes about the inventory item
        public virtual Product Product { get; set; } // Navigation property to the Product
        public virtual Unit Unit { get; set; } // Navigation property to the Unit
    }
}
