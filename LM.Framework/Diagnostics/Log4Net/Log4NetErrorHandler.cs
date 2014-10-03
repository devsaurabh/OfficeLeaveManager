#region using

using System;

#endregion

namespace LM.Framework.Diagnostics.Log4Net
{
    public class Log4NetErrorHandler : IErrorHandler
    {
        #region IErrorHandler Members

        public void Error(string message)
        {
            Error(message, null);
        }

        public void Error(string message, Exception exception)
        {
            Error(message, exception, ErrorCode.GenericFailure);
        }

        public void Error(string message, Exception exception, ErrorCode errorCode)
        {
            var log4NetException = new Exception(message, exception);
            log4NetException.Data.Add("errorCode", errorCode);
            new ElmahLogger().LogException(log4NetException);
        }

        #endregion
    }
}