using System;
using com.Halcyon.Core.Manager;

namespace com.Halcyon.API.Manager
{
    public static class GameLoggerApi
    {
        static GameLoggerApi()
        {
        }

        public static void Log(string message, ILogType logType = ILogType.Log, string stackTrace = "",
            Exception? exception = null)
        {
            GameLogger.Log(message, logType, stackTrace, exception);
        }
    }
}