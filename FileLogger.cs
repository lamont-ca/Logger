using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogger : ILogger
    {
        public void Log(string logType, string message)
        {
            // SET Enviornment
            string environment = ConfigurationManager.AppSettings["DevlEnvironment"];
            //string environment = ConfigurationManager.AppSettings["ProdEnvironment"];

            string allMessagesfilePath   = String.Format("C:\\temp\\{0}\\log.txt",        environment);
            string infoMessagesfilePath  = String.Format("C:\\temp\\{0}\\infolog.txt",    environment);
            string debugMessagesfilePath = String.Format("C:\\temp\\{0}\\debuglog.txt",   environment);
            string warnMessagesfilePath  = String.Format("C:\\temp\\{0}\\warninglog.txt", environment);
            string errorMessagesfilePath = String.Format("C:\\temp\\{0}\\errorlog.txt",   environment);

            // Additional Log types can be created and written to.
            // Logging Tests
            using (StreamWriter streamWriter = new StreamWriter(allMessagesfilePath, true))
            {
                switch (logType)
                {
                    case "Debug":
                        streamWriter.WriteLine("Debug       : " + DateTime.Now + message);
                        LogMessage(logType, message, debugMessagesfilePath);
                        break;
                    case "Information":
                        streamWriter.WriteLine("Information : " + DateTime.Now + message);
                        LogMessage(logType, message, infoMessagesfilePath);
                        break;
                    case "Warning":
                        streamWriter.WriteLine("Warning     : " + DateTime.Now + message);
                        LogMessage(logType, message, warnMessagesfilePath);
                        break;
                    case "Error":
                        streamWriter.WriteLine("Error       : " + DateTime.Now + message);
                        LogMessage(logType, message, errorMessagesfilePath);
                        break;

                }
            }

        }

        /// <summary>
        /// Writes the messages to the correct log
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        public void LogMessage(string logType, string message, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(logType + " : " + DateTime.Now + message);
            }
        }
    }
}
