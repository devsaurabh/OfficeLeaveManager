#region using

using System;

#endregion

namespace LM.Framework.Diagnostics
{
    public class ElmahLogger
    {
        public void LogException(Exception exception)
        {
            if (exception == null) return;

            var context = ErrorSignal.FromCurrentContext();
            if (context != null)
            {
                context.Raise(exception);
            }
        }
    }
}