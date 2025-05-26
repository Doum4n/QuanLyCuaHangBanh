using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO.Base;

namespace QuanLyCuaHangBanh.DTO
{
    public class Product_UnitDTO
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int InventoryID { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Status status { get; set; }

        public bool IsChecked { get; set; }

        public Product_UnitDTO() { }

        public Product_UnitDTO(
            int id,
            int productId,
            int unitId,
            string unitName,
            int inventoryId,
            decimal conversionRate,
            decimal unitPrice,
            int quantity,
            bool isChecked = false
        )
        {
            ID = id;
            ProductID = productId;
            UnitID = unitId;
            UnitName = unitName;
            InventoryID = inventoryId;
            ConversionRate = conversionRate;
            UnitPrice = unitPrice;
            Quantity = quantity;
            IsChecked = isChecked;
        }

        public Product_Unit ToProductUnit()
        {
            return new Product_Unit
            {
                ID = 0,
                UnitID = UnitID,
                ProductID = ProductID,
                ConversionRate = ConversionRate,
                UnitPrice = UnitPrice,
            };
        }

        public override string ToString()
        {
            return $"ID: {ID}, ProductID: {ProductID}, UnitID: {UnitID}, UnitName: {UnitName}, InventoryID: {InventoryID}, ConversionRate: {ConversionRate}, UnitPrice: {UnitPrice}, Quantity: {Quantity}";
        }
    }

}
