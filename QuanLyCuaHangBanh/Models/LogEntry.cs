using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;

namespace QuanLyCuaHangBanh.Models
{
    public class LogEntry
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } // Thời gian xảy ra log
        public LogLevel Level { get; set; }       // Cấp độ log (Debug, Info, Error, ...)

        public string Message { get; set; }

        public string Application { get; set; } = "QuanLyCuaHangBanh";

        public string Source { get; set; } // Tên lớp hoặc thành phần phát sinh log hoặc tên nhân viên thực hiện hành động
    }
}
