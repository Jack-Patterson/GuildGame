using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using com.Halcyon.API.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Manager
{
    public static class GameLogger
    {
        private static readonly string CurrentFilePath;

        static GameLogger()
        {
            Application.logMessageReceived += LogToFile;
            
            int logFileCounter = UpdateLogFileCounter();
            CurrentFilePath = ConstructCurrentFilePath(logFileCounter);
        }

        internal static void Init()
        {
            Log("Initialising Logger.");
        }

        private static void LogToFile(string message, string stackTrace, LogType logType)
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
                    throw new ArgumentOutOfRangeException($"Argument is out of range of {nameof(logType)}. Initial Message:\n{message}");
            }
        }
        
        internal static void Log(string message)
        {
            Log(message, LogType.Log);
        }

        internal static void Log(string message, ILogType logType = ILogType.Log, string? stackTrace = null,
            Exception? exception = null)
        {
            LogType unityLogType = ConvertLogTypeToUnityLogType(logType);
            
            Log(message, unityLogType, stackTrace, exception);
        }

        internal static void Log(string message, LogType logType = LogType.Log, string? stackTrace = null, Exception? exception = null)
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
                default:
                    throw new ArgumentOutOfRangeException($"Argument is out of range of {nameof(logType)}. Initial Message:\n{message}");
            }
        }

        private static LogType ConvertLogTypeToUnityLogType(ILogType logType)
        {
            switch (logType)
            {
                case ILogType.Log:
                    return LogType.Log;
                case ILogType.Assert:
                    return LogType.Assert;
                case ILogType.Exception:
                    return LogType.Exception;
                case ILogType.Error:
                    return LogType.Error;
                case ILogType.Warning:
                    return LogType.Warning;
            }

            return LogType.Log;
        }

        private static void LogToFile(string message)
        {
            File.AppendAllText(CurrentFilePath, message);
        }

        private static string ConstructLogMessage(string message, string severity, string? stackTrace = null)
        {
            string currentTimeAsString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"[{severity}][{currentTimeAsString}] {message}\n{(stackTrace != null && !stackTrace.Equals("") ? stackTrace : "")}";

            return logMessage;
        }

        private static int UpdateLogFileCounter()
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

        private static string ConstructCurrentFilePath(int logFileCounter)
        {
            string path = Path.Combine(Constants.LogsFolderPath, $"{logFileCounter:0000}_session_log.txt").Replace("\\", "/");

            return path;
        }
    }
}