using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class ProductSaleInvoiceDTO : IDisplayProduct
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public int ProductUnitId { get; set; }
        public decimal ConversionRate { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

        public decimal Price { get; set; }
        public int InvoiceID { get; set; }

        public ProductSaleInvoiceDTO(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, decimal price)
        {
            ID = iD;
            ProductName = productName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            UnitName = unitName;
            ProductUnitId = productUnitId;
            ConversionRate = conversionRate;
            Quantity = quantity;
            Note = note;
            Price = price;
        }

        public SalesInvoice_Detail ToSalesInvoiceDetail()
        {
            return new SalesInvoice_Detail()
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
