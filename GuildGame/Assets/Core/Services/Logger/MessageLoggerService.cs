using System;
using UnityEngine;

namespace com.Halkyon.Services.Logger
{
    public class MessageLoggerService : LoggerServiceBase
    {
        protected override void Log(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Error:
                    Debug.LogError(message);
                    break;
                case LogType.Assert:
                default:
                    LoggerService.LogException(new ArgumentOutOfRangeException(nameof(logType), logType, message));
                    break;
            }
        }

        protected override void Log(string message, string stackTrace, LogType logType)
        {
        }

        protected override void LogException(Exception exception)
        {
            Debug.LogException(exception);
        }
    }
}