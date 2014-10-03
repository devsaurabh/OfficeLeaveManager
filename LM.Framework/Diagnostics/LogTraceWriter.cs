#region using

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace LM.Framework.Diagnostics
{
    public class LogTraceWriter : ITraceWriter
    {
        private static readonly Lazy<Dictionary<TraceLevel, ExceptionLevel>> LoggingLevelMap =
            new Lazy<Dictionary<TraceLevel, ExceptionLevel>>(() => new Dictionary<TraceLevel, ExceptionLevel>
                {
                    {TraceLevel.Info, ExceptionLevel.Info},
                    {TraceLevel.Debug, ExceptionLevel.Debug},
                    {TraceLevel.Warn, ExceptionLevel.Warn},
                    {TraceLevel.Error, ExceptionLevel.Error},
                    {TraceLevel.Fatal, ExceptionLevel.Fatal},
                });

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == TraceLevel.Off)
                return;

            var record = new TraceRecord(request, category, level);
            traceAction(record);
            WriteTrace(record);
        }

        protected void WriteTrace(TraceRecord record)
        {
            var message = FormatTrace(record);
            var level = LoggingLevelMap.Value[record.Level];
            ExceptionLogger.GetLogger().Log(level, message, record.Exception);
        }

        protected virtual string FormatTrace(TraceRecord record)
        {
            var message = new StringBuilder();

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append(" ").Append(record.Request.Method.Method);


                if (record.Request.RequestUri != null)
                    message.Append(" ").Append(record.Request.RequestUri.AbsoluteUri);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append(" ").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append(" ").Append(record.Message);

            if (record.Exception != null && !string.IsNullOrEmpty(record.Exception.GetBaseException().Message))
                message.Append(" ").AppendLine(record.Exception.GetBaseException().Message);

            return message.ToString();
        }
    }
}