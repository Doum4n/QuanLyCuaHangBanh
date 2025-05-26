using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Product_Unit
    {
        public int ID { get; set; } // Unique identifier for the product unit
        public int ProductID { get; set; } // Foreign key to the Product table
        public int UnitID { get; set; } // Foreign key to the Unit table
        public decimal UnitPrice { get; set; } // Price of the product in this unit
        public decimal ConversionRate { get; set; } // Conversion rate between product and unit

        public virtual Product Product { get; set; } // Navigation property to the Product
        public virtual Unit Unit { get; set; } // Navigation property to the Unit
        public virtual Inventory? Inventory { get; set; } // Navigation property to the Inventory

        public override string ToString()
        {
            return $"ID: {ID}, ProductID: {ProductID}, UnitID: {UnitID}, Conversion: {ConversionRate}";
        }
    }
}
