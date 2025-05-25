using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO.Base
{
    public enum Status
    {
        New,
        Modified,
        Deleted,
        None
    }
    public abstract class DisplayProduct : IDisplayProduct
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
        public Status Status { get; set; }

        public DisplayProduct(int iD, string productName, int categoryId, string categoryName, string unitName, int productUnitId, decimal conversionRate, int quantity, string note)
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
        }
    }
}
