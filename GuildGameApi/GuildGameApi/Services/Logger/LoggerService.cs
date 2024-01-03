using UnityEngine;

namespace com.Halcyon.API.Services.Logger;

public abstract class LoggerService
{
    public void Log(LoggerParameters loggerParameters)
    {
        Log(loggerParameters.Message, loggerParameters.LogType, loggerParameters.Exception);
    }

    /// <summary>
    /// Test
    /// </summary>
    /// <param name="message"></param>
    /// <param name="logType"></param>
    /// <param name="exception"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Log(string message, LogType logType = LogType.Log, Exception? exception = null)
    {
        if (!char.IsPunctuation(message.TrimEnd().LastOrDefault()))
        {
            message += ".";
        }
        
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
            case LogType.Exception:
                Debug.LogException(exception);
                break;
            case LogType.Assert:
            default:
                throw new ArgumentOutOfRangeException(nameof(logType), logType, message);
        }
    }

    public void Log(object message, LogType logType = LogType.Log, Exception? exception = null)
    {
        Log(message.ToString(), logType, exception);
    }
    
    public void LogException(Exception exception)
    {
        Log("", LogType.Exception, exception);
    }
}