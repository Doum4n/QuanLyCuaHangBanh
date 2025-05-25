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
    public class ProductReleaseDTO : DisplayProduct
    {
        public ProductReleaseDTO(int id, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note) : 
            base(id, productName, categoryId, categoryName, unitName, productUnitId, conversionRate, quantity, note)
        {
            ID = id;
            ProductName = productName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            UnitName = unitName;
            ProductUnitId = productUnitId;
            ConversionRate = conversionRate;
            Quantity = quantity;
            Note = note;
        }

        public int ID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public int ProductUnitId { get; set; }
        public decimal ConversionRate { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }


        public int WarehouseReleaseNoteId { get; set; }

        public bool IsNewlyAdded { get; set; } = false;


        //public ProductReleaseDTO(int id, string productName, int categoryId, string categoryName,
        //    string unitName, int productUnitId, decimal conversionRate,
        //    int quantity, string note)
        //{
        //    ID = id;
        //    ProductName = productName;
        //    CategoryId = categoryId;
        //    CategoryName = categoryName;
        //    UnitName = unitName;
        //    ProductUnitId = productUnitId;
        //    ConversionRate = conversionRate;
        //    Quantity = quantity;
        //    Note = note;
        //}

        internal WarehouseReleaseNote_Detail ToWarehouseReleaseNoteDetail()
        {
            return new WarehouseReleaseNote_Detail
            {
                ID = ID,
                WarehouseReleaseNoteId = WarehouseReleaseNoteId,
                Product_UnitID = ProductUnitId,
                Quantity = (int)Quantity,
                Note = Note,
            };
        }
    }

}
