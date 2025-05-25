using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class ProductOrderDTO : DisplayProduct
    {
        public int OrderId { get; set; } // ID của đơn hàng (tham chiếu Order)
        public decimal Price { get; set; } // Giá của sản phẩm tại thời điểm đặt hàng

        public ProductOrderDTO(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, int orderId, decimal price) :
            base(iD, productName, categoryId, categoryName, unitName, productUnitId, conversionRate, quantity, note)
        {
            OrderId = orderId;
            Price = price;
        }


        //public ProductOrderDTO(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, int orderId)
        //{
        //    ID = iD;
        //    ProductName = productName;
        //    CategoryId = categoryId;
        //    CategoryName = categoryName;
        //    UnitName = unitName;
        //    ProductUnitId = productUnitId;
        //    ConversionRate = conversionRate;
        //    Quantity = quantity;
        //    Note = note;
        //    OrderId = orderId;
        //}

        public Order_Detail ToOrderDetail()
        {
            return new Order_Detail
            {
                ID = ID,
                OrderId = this.OrderId,
                Quantity = this.Quantity,
                Product_UnitID = this.ProductUnitId,
                Price = Price,
                Note = Note
            };
        }
    }
}
