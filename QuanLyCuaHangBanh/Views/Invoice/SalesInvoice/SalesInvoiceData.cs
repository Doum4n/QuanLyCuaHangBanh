using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views.Invoice.SalesInvoice
{
    public class SalesInvoiceData
    {
        public Models.SalesInvoice SalesInvoice { get; set; }
        public AccountsReceivable? AccountsReceivable { get; set; }

        public SalesInvoiceData(Models.SalesInvoice salesInvoice, AccountsReceivable? accountsReceivable = null)
        {
            SalesInvoice = salesInvoice;
            AccountsReceivable = accountsReceivable;
        }
    }
} 