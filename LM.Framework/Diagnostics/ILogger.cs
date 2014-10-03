#region using

using System;

#endregion

namespace LM.Framework.Diagnostics
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        void Log(ExceptionLevel level, string message, Exception exception = null);

        void LogDebug(string message, Exception exception = null);
        void LogInfo(string message, Exception exception = null);
        void LogWarn(string message, Exception exception = null);
        void LogError(string message, Exception exception = null);
        void LogFatal(string message, Exception exception = null);
    }
}