#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using com.Halcyon.API.Services.Logger;
using UnityEngine;

namespace com.Halcyon.Core.Manager
{
    public class GameLogger : LoggerService
    {
        private readonly string _currentFilePath;

        public GameLogger()
        {
            if (!Directory.Exists(Constants.LogsFolderPath))
            {
                GameInitializer.CreateFolder(Constants.LogsFolderPath);
            }

            Application.logMessageReceived += LogToFile;

            int logFileCounter = UpdateLogFileCounter();
            _currentFilePath = ConstructCurrentFilePath(logFileCounter);
        }

#pragma warning disable CS0108, CS0114
        public static void Log(string message, LogType logType = LogType.Log, Exception? exception = null)
        {
            GameManager.Instance.Logger.Log(message, logType, exception);
        }
        
        public static void Log(object message, LogType logType = LogType.Log, Exception? exception = null)
        {
            GameManager.Instance.Logger.Log(message, logType, exception);
        }
        
        public static void Log(LoggerParameters loggerParameters)
        {
            GameManager.Instance.Logger.Log(loggerParameters);
        }
        
        public static void LogException(Exception exception)
#pragma warning restore CS0108, CS0114
        {
            GameManager.Instance.Logger.LogException(exception);
        }

        private void LogToFile(string message, string stackTrace, LogType logType)
        {
            switch (logType)
            {
                case LogType.Log:
                    LogToFile(ConstructLogMessage(message, "Normal"));

                    break;
                case LogType.Warning:
                    LogToFile(ConstructLogMessage(message, "Warning"));

                    break;
                case LogType.Error:
                    LogToFile(ConstructLogMessage(message, "Error", stackTrace));

                    break;
                case LogType.Exception:
                    LogToFile(ConstructLogMessage(message, "Exception", stackTrace));

                    break;
                case LogType.Assert:
                    LogToFile(ConstructLogMessage(message, "Assertion", stackTrace));

                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"Argument is out of range of {nameof(logType)}. Initial Message:\n{message}");
            }
        }

        private void LogToFile(string message)
        {
            File.AppendAllText(_currentFilePath, message);
        }

        private string ConstructLogMessage(string message, string severity, string stackTrace = "")
        {
            string currentTimeAsString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage =
                $"[{severity}][{currentTimeAsString}] {message}\n{(!stackTrace.Equals("") ? stackTrace : "")}";

            return logMessage;
        }

        private int UpdateLogFileCounter()
        {
            string[] existingLogs = Directory.GetFiles(Constants.LogsFolderPath, "*_session_log.txt");

            if (existingLogs.Length > 0)
            {
                IEnumerable<int> numbers =
                    existingLogs.Select(log => int.Parse(Path.GetFileNameWithoutExtension(log).Split('_')[0]));
                return numbers.Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        private string ConstructCurrentFilePath(int logFileCounter)
        {
            string path = Path.Combine(Constants.LogsFolderPath, $"{logFileCounter:0000}_session_log.txt")
                .Replace("\\", "/");

            return path;
        }
    }
}