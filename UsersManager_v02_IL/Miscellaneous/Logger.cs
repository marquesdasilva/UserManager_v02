using log4net;
using log4net.Config;
using System;

namespace UserManager_v02_IL.Miscellaneous
{
    public enum SeverityLevel
    {
        Info = 0,
        Normal = 1,
        Critical = 2,
        Fatal = 3
    }

    public class Logger
    {
        private static ILog Log;
        
        public Logger(string loggerName)
        {
            Log = LogManager.GetLogger(loggerName);
            XmlConfigurator.Configure();
        }
        
        public void LogException(Exception ex, SeverityLevel severityLevel)
        {
            if (Log != null)
            {
                switch (severityLevel)
                {
                    case SeverityLevel.Critical:
                        Log.Error(string.Format("{0} {1}", severityLevel.ToString().ToUpper(), ex.Message), ex);
                        break;
                    case SeverityLevel.Fatal:
                        Log.Fatal(string.Format("{0} {1}", severityLevel.ToString().ToUpper(), ex.Message), ex);
                        break;
                    default:
                        Log.Info(string.Format("{0} {1}", severityLevel.ToString().ToUpper(), ex.Message), ex);
                        break;
                }
            }
        }
    }
}
