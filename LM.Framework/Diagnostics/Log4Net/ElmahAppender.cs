#region using

using System;

#endregion

namespace LM.Framework.Diagnostics.Log4Net
{
    //Link: https://github.com/edwinf/log4net---ELMAH-Appender
    public class ElmahAppender : AppenderSkeleton
    {
        private string _hostName;
        private ErrorLog _errorLog;

        public bool UseNullContext { get; set; }

        public override void ActivateOptions()
        {
            base.ActivateOptions();
            _hostName = Environment.MachineName;
            try
            {
                _errorLog = ErrorLog.GetDefault(null);
            }
            catch (Exception ex)
            {
                ErrorHandler.Error("Could not create default ELMAH error log", ex);
            }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (_errorLog != null)
            {
                Error error = loggingEvent.ExceptionObject != null
                                  ? new Error(loggingEvent.ExceptionObject)
                                  : new Error();
                error.Time = DateTime.Now;
                if (loggingEvent.MessageObject != null)
                {
                    error.Message = loggingEvent.MessageObject.ToString();
                }
                error.Detail = RenderLoggingEvent(loggingEvent);
                error.HostName = _hostName;
                error.User = loggingEvent.Identity;
                error.Type = "log4net - " + loggingEvent.Level; // maybe allow the type to be customized?				
                _errorLog.Log(error);
            }
        }
    }
}