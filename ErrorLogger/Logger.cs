using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextLogger
{
    /// <summary>
    /// Singleton Instance writes string to LogFile
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Default file log file is C:\Log.txt
        /// you can overwrite with a valid file
        /// if invalid file is given, exception will be written in C:\Logger.txt
        /// </summary>
        public string LogFile = @"C:\Log.txt";
        private static Logger logger;
        public static Logger Instance
        {
            get
            {
                if (logger == null)
                    logger = new Logger();
                return logger;
            }
        }

        public void Log(string message)
        {
            Write(message);
        }

        public void Log(string message, string file)
        {
            LogFile = file;
            Write(message);
        }

        private void Write(string message)
        {
            try
            {
                System.IO.File.AppendAllText(LogFile, "Log at :" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " message:" + message + Environment.NewLine);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(@"C:\Logger.txt", "Could not wrte to Log at :" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " message:" + e.Message + " stackTrace:" + e.StackTrace + Environment.NewLine);
            }
        }
    }
}
