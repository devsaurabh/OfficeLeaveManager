#region using

using System;

#endregion

namespace LM.Framework.Diagnostics
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _logger;

        public Log4NetLogger()
        {
            //By default - It will get pick the root level _logger
            _logger = LogManager.GetLogger(String.Empty);
        }

        public Log4NetLogger(string loggerName)
        {
            if (string.IsNullOrWhiteSpace(loggerName))
            {
                throw new ArgumentException("Logger Name is not defined");
            }
            _logger = LogManager.GetLogger(loggerName);
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled; }
        }

        public void LogDebug(string message, Exception exception = null)
        {
            _logger.Debug(message, exception);
        }

        public void LogInfo(string message, Exception exception = null)
        {
            _logger.Info(message, exception);
        }

        public void LogWarn(string message, Exception exception = null)
        {
            _logger.Warn(message, exception);
        }

        public void LogError(string message, Exception exception = null)
        {
            _logger.Error(message, exception);
        }

        public void LogFatal(string message, Exception exception = null)
        {
            _logger.Fatal(message, exception);
        }

        public void Log(ExceptionLevel level, string message, Exception exception = null)
        {
            switch (level)
            {
                case ExceptionLevel.Debug:
                    {
                        _logger.Debug(message, exception);
                        break;
                    }
                case ExceptionLevel.Info:
                    {
                        _logger.Info(message, exception);
                        break;
                    }
                case ExceptionLevel.Warn:
                    {
                        _logger.Warn(message, exception);
                        break;
                    }
                case ExceptionLevel.Error:
                    {
                        _logger.Error(message, exception);
                        break;
                    }
                case ExceptionLevel.Fatal:
                    {
                        _logger.Fatal(message, exception);
                        break;
                    }
            }
        }
    }
}