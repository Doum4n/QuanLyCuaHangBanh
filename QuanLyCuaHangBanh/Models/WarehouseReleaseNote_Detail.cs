using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class WarehouseReleaseNote_Detail
    {
        public int ID { get; set; }
        public int WarehouseReleaseNoteId { get; set; } // ID của phiếu xuất hàng (tham chiếu WarehouseReleaseNote)
        public int Quantity { get; set; }
        public int Product_UnitID { get; set; } // ID của bảng Product_Unit (tham chiếu Product_Unit)
        public string? Note { get; set; }
        // Navigation properties
        public virtual Product_Unit? Product_Unit { get; set; } // Tham chiếu đến bảng Product_Unit
        public virtual WarehouseReleaseNote? WarehouseReleaseNote { get; set; }

    }
}
