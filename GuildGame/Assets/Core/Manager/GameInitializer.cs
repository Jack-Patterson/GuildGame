using System;
using System.IO;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Modding;
using com.Halcyon.Core.Services.Input;
using com.Halcyon.Core.Services.Scenes;
using com.Halcyon.Core.Services.Serialization;
using UnityEngine;

namespace com.Halcyon.Core.Manager
{
    public static class GameInitializer
    {
        public static event Action GameInitializationComplete;

        internal static void InitialGameStartup()
        {
            GameLogger.Init();

            GameLogger.Log("Beginning initial game startup.");


            ValidateAndCreateFolders();
            GameManager.Instance.GameParameters = new GameParameters(new JsonDataService(), new SceneService(),
                new InputService(), GameState.MainMenu);
            HandleCommandLineArguments();

            GameInitializationComplete?.Invoke();
            
            ModsInitializer.CollectAndInitialiseAllMods();
        }

        private static void HandleCommandLineArguments()
        {
            string[] startupArguments = Environment.GetCommandLineArgs();

            foreach (string argument in startupArguments)
            {
                if (argument.Equals("-developerMode"))
                {
                    GameLogger.Log("Dev mode");
                }
            }
        }

        private static void ValidateAndCreateFolders()
        {
            if (!ValidateFolderExists(Constants.LogsFolderPath))
            {
                CreateFolder(Constants.LogsFolderPath);
            }

            if (!ValidateFolderExists(Constants.ModsFolderPath))
            {
                CreateFolder(Constants.ModsFolderPath);
            }

            if (!ValidateFolderExists(Constants.SavesFolderPath))
            {
                CreateFolder(Constants.SavesFolderPath);
            }
        }

        private static bool ValidateFolderExists(string path)
        {
            if (Directory.Exists(path))
            {
                GameLogger.Log($"Folder {path.Split("/")[^1]} already exists.");
                return true;
            }

            GameLogger.Log($"Folder {path.Split("/")[^1]} does not exist. Creating folder.", LogType.Warning);
            return false;
        }

        internal static void CreateFolder(string path)
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