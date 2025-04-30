using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class UnitDTO
    {
        public int ID { get; set; }
        public int ProductUnitId { get; set; }
        public string UnitName { get; set; }
        public bool IsSelected { get; set; }

        public UnitDTO(int id, string name, int productUnitId, bool isSelected)
        {
            ID = id;
            UnitName = name;
            ProductUnitId = productUnitId;
            IsSelected = isSelected;
        }
    }

}
