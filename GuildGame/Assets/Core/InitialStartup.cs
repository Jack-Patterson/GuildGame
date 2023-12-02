using System;
using System.IO;
using UnityEngine;

namespace com.Halcyon.Core
{
    public class InitialStartup : MonoBehaviour
    {
        private void Start()
        {
            if (!Directory.Exists(Constants.ModsFolderPath))
            {
                CreateModsFolder();
            }
        }

        private void CreateModsFolder()
        {
            try
            {
                Directory.CreateDirectory(Constants.ModsFolderPath);
                Debug.Log("Mods folder created at: " + Constants.ModsFolderPath);
            }
            catch (Exception e)
            {
                Debug.LogError("Error creating Mods folder: " + e.Message);
            }
        }
    }
}