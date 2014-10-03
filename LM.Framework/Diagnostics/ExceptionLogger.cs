#region using

using System;

#endregion

namespace LM.Framework.Diagnostics
{
    //TODO: Move these container Object to Global Containers.
    public class ExceptionLogger
    {
        private static ILogger _logger;

        public static ILogger GetLogger()
        {
            return _logger;
        }

        public static void SetLogger(ILogger logger)
        {
            if (_logger != null)
                throw new Exception("Exception Logger is already set");
            _logger = logger;
        }
    }

    public enum ExceptionLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}