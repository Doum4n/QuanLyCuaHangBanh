using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models.Base
{
    public abstract class Account // Công nợ
    {
        public int ID { get; set; }
        public decimal Amount { get; set; } // Số tiền của khoản nợ/phải thu
        public DateTime TransactionDate { get; set; } // Ngày phát sinh giao dịch
        public DateTime DueDate { get; set; } // Ngày đáo hạn
        public bool IsPaid { get; set; } // Trạng thái đã thanh toán/đã thu
        public DateTime? PaidDate { get; set; } // Ngày thanh toán/thu thực tế (có thể null nếu chưa)
        public string? Note { get; set; } // Ghi chú thêm
        public abstract string GetAccountType();
        public int InvoiceID { get; set; } // Foreign key to the Invoice table
        public virtual Invoice Invoice { get; set; } // Navigation property to the Invoice

    }
}
