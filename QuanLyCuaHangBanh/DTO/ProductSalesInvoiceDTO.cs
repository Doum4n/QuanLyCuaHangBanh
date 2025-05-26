using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class ProductSalesInvoiceDTO : DisplayProduct
    {
        public int InvoiceID { get; set; }
        public decimal Price { get; set; }
        public ProductSalesInvoiceDTO(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, int invoiceId, decimal price) :
            base(iD, productName, categoryId, categoryName, unitName, productUnitId, conversionRate, quantity, note)
        {
            InvoiceID = invoiceId;
            Price = price;
        }

        public SalesInvoice_Detail ToSalesInvoiceDetail()
        {
            return new SalesInvoice_Detail
            {
                Product_UnitID = ProductUnitId,
                Quantity = Quantity,
                UnitPrice = Price,
                Note = Note,
                InvoiceID = InvoiceID
            };
        }
    }
}
