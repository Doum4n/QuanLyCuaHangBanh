using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public abstract class LoggerBase : ILogger
    {
        public abstract void Log(LogLevel level, string message);

        public void LogDebug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void LogInfo(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void LogCritical(string message)
        {
            Log(LogLevel.Critical, message);
        }
    }
}
