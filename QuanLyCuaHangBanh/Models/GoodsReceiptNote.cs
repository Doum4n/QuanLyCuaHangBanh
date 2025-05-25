using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class GoodsReceiptNote
    {
        public int ID { get; set; }
        public int SupplierId { get; set; }
        //public DateTime ReceiptDate { get; set; }
        //public string? ReceiptCode { get; set; } // Mã phiếu nhập (tùy chọn, unique nếu cần)
        // int CreatedById { get; set; } // ID của người tạo phiếu nhập (tham chiếu User)
        [DataType("timestamp WITHOUT time zone")]
        public DateOnly CreatedDate { get; set; }
        public int? LastModifiedById { get; set; } // ID của người cập nhật cuối (tham chiếu User)
        [DataType("timestamp WITHOUT time zone")]
        public DateOnly? LastModifiedDate { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; } // Trạng thái phiếu nhập (ví dụ: Mới, Đã lưu)
        // Navigation property to Supplier
        public virtual Supplier? Supplier { get; set; }
        // Navigation property to User who created the receipt
        //public virtual Employee? CreatedBy { get; set; }
        // Navigation property to User who last modified the receipt
        public virtual Employee? LastModifiedBy { get; set; }
        // Collection of GoodsReceiptNoteDetails
        public virtual ICollection<GoodsReceiptNote_Detail>? GoodsReceiptNoteDetails { get; set; }
    }

}
