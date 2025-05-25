using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class ProductOrderDTO : IDisplayProduct
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
        
        public int OrderId { get; set; } // ID của đơn hàng (tham chiếu Order)

        public ProductOrderDTO(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note, int orderId)
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
            OrderId = orderId;
        }

        public Order_Detail ToOrderDetail()
        {
            return new Order_Detail
            {
                ID = 0,
                OrderId = this.OrderId,
                Quantity = this.Quantity,
                Product_UnitID = this.ProductUnitId,
                Price = 0 // Giá sẽ được tính sau này
            };
        }
    }
}
