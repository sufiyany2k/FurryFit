using System;
using System.Collections.Generic;
using System.Text;

namespace FurryFit.Helpers
{
    public enum LogStatus
    {
        Started,
        Completed
    }

    public class LogHelper
    {
        public void LogTrace(string methodName, LogStatus logStat)
        {
            App.Logger.Trace(methodName + " - " + GetLogStatus(logStat));
        }

        public void LogError(string methodName, Exception error)
        {
            App.Logger.Error(methodName + " - " + error.Message);
        }

        private string GetLogStatus(LogStatus logStatus)
        {
            if (logStatus == LogStatus.Started)
                return "Started";
            if (logStatus == LogStatus.Completed)
                return "Completed";
            else
            {
                return "";
            }
        }
    }
}
