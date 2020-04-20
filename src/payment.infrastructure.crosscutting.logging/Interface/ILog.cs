using System;

namespace AG.PaymentApp.Infrastructure.Crosscutting.Logging.Interface
{
    public interface ILog
    {
        LogLevel MinimumLevel { get; }
        void Error(string message);
        void Error(string message, Func<object> dataFunc);
        void Error(string message, Exception ex);
        void Fatal(string message);
        void Fatal(string message, Func<object> dataFunc);
        void Info(string message);
        void Info(string message, Func<object> dataFunc);
        void Log(LogLevel logLevel, string message);
        void Log(LogLevel logLevel, string message, Func<object> dataFunc);
        void Verbose(string message);
        void Verbose(string message, Func<object> dataFunc);
        void Warning(string message);
        void Warning(string message, Func<object> dataFunc);
    }
}
