using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class WarehouseReleaseNote
    {
        public int ID { get; set; }
        [DataType("timestamp WITHOUT time zone")]
        public DateOnly CreatedDate { get; set; }
        public int CreatedByID { get; set; } // ID của người tạo phiếu xuất (tham chiếu User)
        public int? LastModifiedByID { get; set; } // ID của người cập nhật cuối (tham chiếu User)
        [DataType("timestamp WITHOUT time zone")]

        public DateOnly? LastModifiedDate { get; set; }
        public string? Note { get; set; }

        public string? Status { get; set; } // Trạng thái phiếu xuất (ví dụ: Mới, Đã lưu)
        public int LinkedId { get; set; } // ID liên kết đến bảng khác (nếu có)

        public virtual Employee? CreatedBy { get; set; } // Navigation property to User who created the receipt
        public virtual Employee? LastModifiedBy { get; set; } // Navigation property to User who last modified the receipt
        public virtual ICollection<WarehouseReleaseNote_Detail>? WarehouseReleaseNoteDetails { get; set; } // Collection of WarehouseReleaseNoteDetails
    }
}
