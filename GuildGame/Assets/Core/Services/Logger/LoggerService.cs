#nullable enable
using System;
using UnityEngine;

namespace com.Halkyon.Services.Logger
{
    public static class LoggerService
    {
        public static Action<string, LogType> OnMessageLogged = null!;
        public static Action<Exception> OnExceptionLogged = null!;

        public static void Log(string message, LogType logType = LogType.Log, Exception? exception = null)
        {
            if (exception != null)
                LogException(exception);
            if (logType == LogType.Exception)
                LogException(new ArgumentException("Exception cannot be null when Log Type is Exception."));

            OnMessageLogged?.Invoke(message, logType);
        }

        public static void Log(object message, LogType logType = LogType.Log, Exception? exception = null)
        {
            Log(message.ToString(), logType, exception);
        }

        public static void LogException(Exception exception)
        {
            OnExceptionLogged?.Invoke(exception);
        }
    }
}