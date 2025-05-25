using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Uitls
{
    public static class Session
    {
        public static int EmployeeId { get; set; }
        public static string EmployeeName { get; set; }
        public static string Role { get; set; }
        // Có thể thêm thông tin khác như quyền hạn, chi nhánh, v.v.
        public static void Clear()
        {
            EmployeeId = 0;
            EmployeeName = string.Empty;
            Role = string.Empty;
            // Xóa các thông tin khác nếu cần
        }
    }
}
