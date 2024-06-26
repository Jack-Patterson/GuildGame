﻿#nullable enable
using System;
using UnityEngine;

namespace com.Halkyon.Services.Logger
{
    public class LoggerUserMonoBehaviour : MonoBehaviour
    {
        protected static void Log(string message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message, logType, exception);

        protected static void Print(string message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message, logType, exception);

        protected static void print(string message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message, logType, exception);

        protected static void Log(object message, LogType logType = LogType.Log, Exception? exception = null)
        {
            if (message == null)
                LoggerService.Log("null", logType, exception);
            else
                LoggerService.Log(message.ToString(), logType, exception);
        }

        protected static void print(object message, LogType logType = LogType.Log, Exception? exception = null)
        {
            if (message == null)
                LoggerService.Log("null", logType, exception);
            else
                LoggerService.Log(message.ToString(), logType, exception);
        }

        protected static void LogException(Exception exception) => LoggerService.LogException(exception);
    }
}