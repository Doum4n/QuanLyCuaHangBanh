using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Invoice_Detail
    {
        public int ID { get; set; } // Unique identifier for the invoice detail
        public int InvoiceID { get; set; } // Foreign key to the Invoice table
        public int ProductID { get; set; } // Foreign key to the Product table
        public int Quantity { get; set; } // Quantity of the product in the invoice
        public decimal Price { get; set; } // Price of the product at the time of sale

        public virtual Invoice Invoice { get; set; } // Navigation property to the Invoice
        public virtual Product Product { get; set; } // Navigation property to the Product
    }
}
