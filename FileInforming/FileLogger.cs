using System;
using System.Diagnostics;
using FileInforming.Infrastructure;
using NLog;

namespace FileInforming
{
    public class FileLogger : IFileLogger
    {
        private Logger log;

        public FileLogger()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        public void AddToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void AddToLog(string message, Exception ex)
        {
            log.Error(ex, message);
        }

        public void AddToOutput(string message)
        {
            Debug.WriteLine($"Message from class {message}");
        }
    }
}
