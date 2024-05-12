using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using com.Halkyon.Utils;
using UnityEngine;

namespace com.Halkyon.Services.Logger
{
    public class FileLoggerService : LoggerServiceBase
    {
        private string _currentFilePath;

        protected new void Awake()
        {
            base.Awake();

            if (!Directory.Exists(Constants.LogsFolderPath))
            {
                CreateFolder(Constants.LogsFolderPath);
            }
            
            int logFileCounter = UpdateLogFileCounter();
            _currentFilePath = ConstructCurrentFilePath(logFileCounter);
        }
        
        protected override void Log(string message, LogType logType)
        {
        }

        protected override void Log(string message, string stackTrace, LogType logType)
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
                    LogToFile(ConstructLogMessage(message, "Error"));
                    break;
                case LogType.Exception:
                    LogToFile(ConstructLogMessage(message, "Exception", stackTrace));
                    break;
                case LogType.Assert:
                    LogToFile(ConstructLogMessage(message, "Assertion"));
                    break;
                default:
                    LoggerService.LogException(new ArgumentOutOfRangeException(
                        $"Argument is out of range of {nameof(logType)}. Initial Message:\n{message}"));
                    break;
            }
        }

        protected override void LogException(Exception exception)
        {
            LogToFile(ConstructLogMessage(exception.Message, "Exception", exception.StackTrace));
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
        
        private static void CreateFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error creating folder {path}: {e.Message}");
            }
        }
    }
}