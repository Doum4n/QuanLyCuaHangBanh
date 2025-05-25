using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.DTO
{
   
    public class ProductPurchaseInvoiceDTO : DisplayProduct
    {
        public int InvoiceID { get; set; }
        public decimal Price { get; set; }


        public ProductPurchaseInvoiceDTO(int iD, int invoiceId, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, decimal price) : 
            base(iD, productName, categoryId, categoryName, unitName, productUnitId, conversionRate, quantity, note)
        {
            InvoiceID = invoiceId;
            Price = price;
        }

        public PurchaseInvoice_Detail ToPurchaseInvoice_Detail()
        {
            return new PurchaseInvoice_Detail()
            {
                ID = ID,
                Product_UnitID = ProductUnitId,
                Quantity = Quantity,
                UnitCost = Price,
                Note = Note,
                InvoiceID = InvoiceID
            };
        }
    }
}
