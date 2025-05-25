using QuanLyCuaHangBanh.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class PurchaseInvoice : Invoice
    {
        public int SupplierID { get; set; }
        public string Status { get; set; } // e.g., "Paid", "Unpaid"

        public virtual Supplier Supplier { get; set; } // Navigation property to the Supplier
        public virtual ICollection<Invoice_Detail> InvoiceDetails { get; set; }

    }
}
