using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    // Enum để định nghĩa các cấp độ log
    public enum LogLevel
    {
        Debug,     // Thông tin chi tiết cho việc gỡ lỗi
        Info,      // Thông tin chung về hoạt động của ứng dụng
        Warning,   // Các vấn đề tiềm ẩn hoặc không mong muốn nhưng không gây lỗi
        Error,     // Lỗi xảy ra nhưng ứng dụng có thể tiếp tục hoạt động
        Critical   // Lỗi nghiêm trọng, ứng dụng có thể không tiếp tục hoạt động đúng
    }

    public interface ILogger
    {
        void Log(LogLevel level, string message);
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogCritical(string message);
    }
}
