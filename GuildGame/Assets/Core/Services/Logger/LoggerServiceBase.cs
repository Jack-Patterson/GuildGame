using System;
using UnityEngine;

namespace com.Halkyon.Services.Logger
{
    public abstract class LoggerServiceBase : MonoBehaviour
    {
        protected void Awake()
        {
            LoggerService.MessageLogged += Log;
            LoggerService.ExceptionLogged += LogException;
            Application.logMessageReceived += Log;
        }

        protected abstract void Log(string message, LogType logType);
        protected abstract void Log(string message, string stackTrace, LogType logType);
        protected abstract void LogException(Exception exception);
    }
}