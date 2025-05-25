using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO.Base;

namespace QuanLyCuaHangBanh.DTO
{
    public class PurchaseInvoiceDTO : InvoiceDTO
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public PurchaseInvoiceDTO(int id, string employeeName, int supplierId, string supplierName, DateTime createdDate, decimal totalAmount, string status) : base(id, employeeName, createdDate, totalAmount, status)
        {
            SupplierName = supplierName;
            SupplierID = supplierId;
        }
    }
}
