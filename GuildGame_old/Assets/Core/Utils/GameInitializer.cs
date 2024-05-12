using System;
using System.IO;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Camera;
using com.Halcyon.Core.Modding;
using com.Halcyon.Core.Services.DataHolder;
using com.Halcyon.Core.Services.Input;
using com.Halcyon.Core.Services.Scenes;
using com.Halcyon.Core.Services.Serialization;
using UnityEngine;
using Constants = com.Halcyon.Core.Utils.Constants;

namespace com.Halcyon.Core.Manager
{
    public static class GameInitializer
    {
        public static event Action GameInitializationComplete;
        public static event Action InputInitializationComplete;

        internal static void InitialGameStartup()
        {
            GameManager.Instance.Logger = new GameLogger();
            GameManager.Instance.DataHolder = new DataHolder();
            GameManager.Instance.CameraParameters = new CameraParameters();
            GameManager.Instance.GameParameters = new GameParameters(new JsonSerializationService(), new SceneService(),
                new InputService(), GameState.MainMenu);

            GameManager.Instance.Logger.Log("Beginning initial game startup.");

            InputInitializationComplete?.Invoke();
            
            ValidateAndCreateFolders();
            HandleCommandLineArguments();

            GameInitializationComplete?.Invoke();

            ModsInitializer.CollectAndInitialiseAllMods();
            Services.Serialization.Constants.Load();
        }

        private static void HandleCommandLineArguments()
        {
            string[] startupArguments = Environment.GetCommandLineArgs();

            foreach (string argument in startupArguments)
            {
                if (argument.Equals("-developerMode"))
                {
                    GameManager.Instance.Logger.Log("Dev mode");
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
                GameManager.Instance.Logger.Log($"Folder {path.Split("/")[^1]} already exists.");
                return true;
            }

            GameManager.Instance.Logger.Log($"Folder {path.Split("/")[^1]} does not exist. Creating folder.",
                LogType.Warning);
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