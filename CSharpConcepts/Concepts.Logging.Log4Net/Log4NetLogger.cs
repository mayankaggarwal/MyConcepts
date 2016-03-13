using Concepts.LoggingLayer;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concepts.Logging.Log4Net
{
    /// <summary>
    /// Driver class to adapt calls from ILogger to work with a log4net backend
    /// </summary>
    internal class Log4NetLogger : ILogger
    {
        public Log4NetLogger()
        {
            //Configures log4net by using log4net's XMLConfigurator class
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void WriteMessage(string category, LogLevel level, string message)
        {
            ILog log = LogManager.GetLogger(category);
            switch(level)
            {
                case LogLevel.FATAL:
                    if (log.IsFatalEnabled) log.Error(message);
                    break;
                case LogLevel.ERROR:
                    if (log.IsErrorEnabled) log.Error(message);
                    break;
                case LogLevel.INFO:
                    if (log.IsInfoEnabled) log.Error(message);
                    break;
                case LogLevel.VERBOSE:
                    if (log.IsDebugEnabled) log.Error(message);
                    break;
                case LogLevel.WARN:
                    if (log.IsWarnEnabled) log.Error(message);
                    break;
            }

        }
    }
}
