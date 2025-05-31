using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class SaleInvoiceDTO : InvoiceDTO, ISearchable
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Type { get; set; }
        public string PaymentMethod { get; set; }
        public int CreditPeriod { get; set; }
        public decimal TotalUnpaid { get; set; }
        public string Note { get; set; }
        public SaleInvoiceDTO(int id, string employeeName, DateTime createdDate, decimal totalAmount, string status, int customerId, string customerName, string type, string paymentMethod, int creditPeriod, decimal totalUnpaid, string note) : base(id, employeeName, createdDate, totalAmount, status)
        {
            CustomerID = customerId;
            CustomerName = customerName;
            Type = type;
            PaymentMethod = paymentMethod;
            CreditPeriod = creditPeriod;
            TotalUnpaid = totalUnpaid;
            Note = note;
        }

        public bool MatchesSearch(string searchValue)
        {
            return CustomerName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Type.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   PaymentMethod.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
