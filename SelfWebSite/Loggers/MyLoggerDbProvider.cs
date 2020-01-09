using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SelfWebSite.Loggers
{
    public class MyLoggerDbProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose() { }

        private class MyLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId,
                TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllTextAsync("logDatabase.txt", formatter(state, exception));
                //Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
