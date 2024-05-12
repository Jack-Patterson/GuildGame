#nullable enable
using System;
using com.Halkyon.Services;
using com.Halkyon.Services.Logger;
using UnityEngine;

namespace com.Halkyon
{
    public class ExtendedMonoBehaviour : MonoBehaviour
    {
        public GameManager GameManager => GameManager.Instance;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        protected static void Log(string message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message, logType, exception);

        protected static void Print(string message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message, logType, exception);

        protected static void print(string message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message, logType, exception);

        protected static void Log(object message, LogType logType = LogType.Log, Exception? exception = null) =>
            LoggerService.Log(message.ToString(), logType, exception);

        protected static void LogException(Exception exception) => LoggerService.LogException(exception);
    }
}