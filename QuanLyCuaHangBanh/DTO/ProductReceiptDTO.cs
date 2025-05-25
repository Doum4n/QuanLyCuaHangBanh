using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class ProductReceiptDTO : DisplayProduct
    {
        public ProductReceiptDTO(int iD, int productId, string productName, int categoryId, string categoryName, int unitId, string unitName, int productUnitId, decimal conversionRate, decimal purchasePrice, int quantity, string note) : 
            base(iD, productName, categoryId, categoryName, unitName, productUnitId, conversionRate, quantity, note)
        {
            ProductId = productId;
            UnitId = unitId;
            PurchasePrice = purchasePrice;
            //GoodsReceiptNoteId = goodsReceiptNoteId;
        }

        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public decimal PurchasePrice { get; set; }

        public int GoodsReceiptNoteId { get; set; }


        public GoodsReceiptNote_Detail ToGoodsReceiptNoteDetail()
        {
            return new GoodsReceiptNote_Detail
            {
                ID = ID,
                ProductId = ProductId,
                GoodsReceiptNoteId = GoodsReceiptNoteId,
                ProductUnitId = ProductUnitId,
                Quantity = (int)Quantity,
                UnitId = UnitId,
                PurchasePrice = PurchasePrice,
                Note = Note
            };
        }
    }

}
