using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class GoodsReceiptNote_Detail
    {
        public int ID { get; set; }
        public int GoodsReceiptNoteId { get; set; } // ID của phiếu nhập hàng (tham chiếu GoodsReceiptNote)
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int ProductUnitId { get; set; } // ID của bảng Product_Unit (tham chiếu Product_Unit)

        public decimal PurchasePrice { get; set; } // Giá nhập (tùy chọn)

        public string? Note { get; set; }

        // Navigation properties
        public virtual Product_Unit? ProductUnit { get; set; } // Tham chiếu đến bảng Product_Unit
        public virtual GoodsReceiptNote? GoodsReceiptNote { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Unit? Unit { get; set; }
    }
}
