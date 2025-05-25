using QuanLyCuaHangBanh.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class SalesInvoice_Detail : Invoice_Detail
    {
        public decimal UnitPrice { get; set; }
        public string? Note { get; set; } // Optional note for the invoice detail

        public virtual SalesInvoice SalesInvoice => Invoice as SalesInvoice;
    }
}
