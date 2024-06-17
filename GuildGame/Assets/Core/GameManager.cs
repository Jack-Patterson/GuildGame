using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using com.Halkyon.Input;
using com.Halkyon.Services.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.Halkyon
{
    public class GameManager : ExtendedMonoBehaviour
    {
        private static GameManager _instance;
        
        public Action<GameState> OnGameStateChanged;
        public Action<int> OnMoneyChanged;
        private GameState _currentState = GameState.Play;
        private int _money = 0;

        [SerializeField] private GameObject charPrefab;
        
        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                OnMoneyChanged?.Invoke(_money);
            }
        }

        public static GameManager Instance => _instance;

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