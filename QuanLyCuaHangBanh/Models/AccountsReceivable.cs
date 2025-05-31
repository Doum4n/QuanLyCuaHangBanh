using QuanLyCuaHangBanh.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class AccountsReceivable : Account
    {
        public int CustomerID { get; set; } // Foreign key to the Customer table
        //public int SalesInvoiceID { get; set; } // Foreign key to the SalesInvoice table

        public override string GetAccountType()
        {
            return "Công nợ phải thu"; // Trả về loại công nợ là "Công nợ phải thu"
        }

        public virtual Customer Customer { get; set; } // Navigation property to the Customer
//        public virtual SalesInvoice SalesInvoice { get; set; } // Navigation property to the SalesInvoice
    }
}
