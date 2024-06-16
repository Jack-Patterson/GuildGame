using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using com.Halkyon.Input;
using com.Halkyon.Services.Logger;
using UnityEngine;

namespace com.Halkyon
{
    public class GameManager : ExtendedMonoBehaviour
    {
        private static GameManager _instance;
        
        public Action<GameState> OnGameStateChanged;
        private GameState _currentState = GameState.Play;

        [SerializeField] private GameObject charPrefab;

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
        
        public GameState CurrentState => _currentState;

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
        
        public void ChangeState(GameState newState)
        {
            if (_currentState == newState)
                return;
            
            _currentState = newState;
            OnGameStateChanged?.Invoke(newState);
            Log($"Game state changed to {newState}");
        }
    }
}