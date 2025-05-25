using QuanLyCuaHangBanh.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class PurchaseInvoice_Detail : Invoice_Detail
    {
        public decimal UnitCost { get; set; }
        public string? Note { get; set; }
        public virtual PurchaseInvoice PurchaseInvoice => Invoice as PurchaseInvoice; // Chỉ rõ liên kết đến SalesInvoice kế thừa từ Invoice

    }
}
