using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public DateTime Date { get; set; } // Date of the invoice
        public int EmployeeID { get; set; } // ID of the employee who created the invoice
        public int CustomerID { get; set; } // ID of the customer

        public virtual ICollection<Invoice_Detail> InvoiceDetails { get; } = new List<Invoice_Detail>();
        public virtual Employee Employee { get; set; } // Navigation property to the Employee
        public virtual Custumer Customer { get; set; } // Navigation property to the Customer
    }
}
