using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.DTO
{
    public class PurchaseInvoiceDTO : InvoiceDTO, ISearchable
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int CreditPeriod { get; set; }
        public decimal TotalUnpaid { get; set; }
        public string Note { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public PurchaseInvoiceDTO(int id, string employeeName, int supplierId, string supplierName, DateTime createdDate, decimal totalAmount, string status, int creditPeriod, decimal totalUnpaid, string note, string paymentMethod) : base(id, employeeName, createdDate, totalAmount, status)
        {
            SupplierName = supplierName;
            SupplierID = supplierId;
            CreditPeriod = creditPeriod;
            TotalUnpaid = totalUnpaid;
            Note = note;
            PaymentMethod = paymentMethod;
        }

        internal PurchaseInvoice ToEntity()
        {
            return new PurchaseInvoice
            {
                ID = ID,
                SupplierID = SupplierID,
                Status = Status,
                PaymentMethod = PaymentMethod,
            };
        }

        public bool MatchesSearch(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue)) return true;
            searchValue = searchValue.ToLower();
            return SupplierName.ToLower().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Status.ToLower().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   TotalAmount.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   CreditPeriod.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   TotalUnpaid.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
