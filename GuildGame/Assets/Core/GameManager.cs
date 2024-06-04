using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using com.Halkyon.Services.Logger;
using UnityEngine;

namespace com.Halkyon
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    _instance = gameManagerObject.AddComponent<GameManager>();
                    DontDestroyOnLoad(gameManagerObject);
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }

            CreateLoggersIfNotExists();
        }

        private void CreateLoggersIfNotExists()
        {
            IEnumerable<Type> loggerTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(LoggerServiceBase)));

            foreach (Type type in loggerTypes)
            {
                LoggerServiceBase existingLogger = (LoggerServiceBase)FindObjectOfType(type);
                if (existingLogger == null)
                {
                    GameObject loggerServiceObject = FindOrCreateLoggerServiceObject();
                    loggerServiceObject.AddComponent(type);
                }
            }
        }

        private GameObject FindOrCreateLoggerServiceObject()
        {
            GameObject loggerServiceObject = GameObject.Find("LoggerService");

            if (loggerServiceObject == null)
                loggerServiceObject = new GameObject("LoggerService");

            return loggerServiceObject;
        }
    }
}