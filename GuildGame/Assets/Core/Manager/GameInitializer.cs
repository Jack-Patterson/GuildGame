using System;
using System.IO;
using com.Halcyon.Core.Modding;
using UnityEngine;

namespace com.Halcyon.Core.Manager
{
    public static class GameInitializer
    {
        internal static void InitialGameStartup()
        {
            GameLogger.Init();

            GameLogger.Log("Beginning initial game startup.");

            ValidateAndCreateFolders();
            ModsInitialiser.CollectAndInitialiseAllMods();
            HandleCommandLineArguments();
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