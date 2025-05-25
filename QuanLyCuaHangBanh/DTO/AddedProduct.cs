using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class AddedProduct
    {
        public int ID { get; set; }
        public string UnitName { get; set; }
        public int UnitId { get; set; }

        public AddedProduct(int id, int unitId, string unitName)
        {
            ID = id;
            UnitId = unitId;
            UnitName = unitName;
        }
    }
}
