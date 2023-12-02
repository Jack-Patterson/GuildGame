using UnityEngine;

namespace com.Halcyon.API.Manager;

public static class GameLogger
{
    public static void Log(GameLoggerParameters loggerParameters)
    {
        Log(loggerParameters.Message, loggerParameters.LogType, loggerParameters.Exception);
    }
    
    public static void Log(string message, LogType logType = LogType.Log, Exception? exception = null)
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
            case LogType.Exception:
                Debug.LogException(exception);
                break;
            case LogType.Assert:
            default:
                throw new ArgumentOutOfRangeException(nameof(logType), logType, message);
        }
    }

    public static void LogException(Exception exception)
    {
        Log("", LogType.Exception, exception);
    }
}