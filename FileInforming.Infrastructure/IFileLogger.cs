using System;

namespace FileInforming.Infrastructure
{
    public interface IFileLogger
    {
        void AddToLog(string message, Exception ex);
        void AddToConsole(string message);
        void AddToOutput(string message);
    }
}
