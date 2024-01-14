﻿using com.Halcyon.API.Services.Logger;
using UnityEngine;

namespace com.Halcyon.API.Core;

public abstract class LoggerUtilMonoBehaviour: MonoBehaviour
{
    public static void Log(string message, LogType logType = LogType.Log, Exception? exception = null)
    {
        GameManagerBase.Instance.Logger.Log(message, logType, exception);
    }
    
    public static void Log(object message, LogType logType = LogType.Log, Exception? exception = null)
    {
        GameManagerBase.Instance.Logger.Log(message, logType, exception);
    }

    public static void Log(LoggerParameters loggerParameters)
    {
        GameManagerBase.Instance.Logger.Log(loggerParameters);
    }

    public static void LogException(Exception exception)
    {
        GameManagerBase.Instance.Logger.LogException(exception);
    }
}