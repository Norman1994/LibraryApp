using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.API.Utilities
{
    public class FileLogger : ILogger, IDisposable
    {
        string filePath;
        static object _lock = new object();

        public FileLogger(string path)
        {
            filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {}

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Error;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = DateTime.Now + ": " + formatter(state, exception) + ", " + GetType().Name.ToString();

            lock (_lock)
            {
                File.AppendAllText(filePath, message + Environment.NewLine);
            }
        }
    }
}
