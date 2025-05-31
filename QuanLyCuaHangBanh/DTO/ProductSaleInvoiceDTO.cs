using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO.Base;

namespace QuanLyCuaHangBanh.DTO
{
    public class ProductSaleInvoiceDTO(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, decimal price) : DisplayProduct(iD, productName, categoryId, categoryName, unitName, productUnitId, conversionRate, quantity, note)
    {
        public decimal Price { get; set; } = price;
        public int InvoiceID { get; set; }

        public SalesInvoice_Detail ToSalesInvoiceDetail()
        {
            return new SalesInvoice_Detail()
            {
                ID = ID,
                Product_UnitID = ProductUnitId,
                Quantity = Quantity,
                UnitPrice = Price,
                Note = Note,
                InvoiceID = InvoiceID
            };
        }
    }
}
