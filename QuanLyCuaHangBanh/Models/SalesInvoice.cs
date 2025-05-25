using QuanLyCuaHangBanh.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class SalesInvoice : Invoice 
    {
        public int CustomerID { get; set; } // ID of the customer

        public string PaymentMethod { get; set; }

        public string Status { get; set; } // e.g., "Paid", "Unpaid", "Refunded"

        public virtual Customer Customer { get; set; }
        // ✅ Ánh xạ navigation từ Invoice_Detail (kế thừa)
        public ICollection<Invoice_Detail> InvoiceDetails { get; set; }
    }
}
