#nullable enable
using System;
using UnityEngine;

namespace com.Halkyon.Services.Logger
{
    public static class LoggerService
    {
        public static Action<string, LogType> MessageLogged = null!;
        public static Action<Exception> ExceptionLogged = null!;
        
        public static void Log(string message, LogType logType = LogType.Log, Exception? exception = null)
        {
            if (exception != null)
                LogException(exception);
            if (logType == LogType.Exception)
                LogException(new ArgumentException("Exception cannot be null when Log Type is Exception."));
            
            MessageLogged?.Invoke(message, logType);
        }

        public static void LogException(Exception exception)
        {
            ExceptionLogged?.Invoke(exception);
        }
    }
}