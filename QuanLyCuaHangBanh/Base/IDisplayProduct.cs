using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public interface IDisplayProduct
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


    }
}
