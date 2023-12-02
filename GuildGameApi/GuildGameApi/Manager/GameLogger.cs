using UnityEngine;

namespace com.Halcyon.API.Manager;

public static class GameLogger
{
    public static void Log(string message, LogType logType, Exception? exception)
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
}