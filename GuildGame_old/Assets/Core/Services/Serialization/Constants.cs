using System;
using System.IO;
using com.Halcyon.API.Core;
using Newtonsoft.Json;
using UnityEngine;

namespace com.Halcyon.Core.Services.Serialization
{
    public class Constants : LoggerUtilMonoBehaviour
    {
        public static Constants Instance;
        
        private string ModsFolderPath = Path.Combine(Application.persistentDataPath, "Mods").Replace("\\", "/");

        private string LogsFolderPath = Path.Combine(Application.persistentDataPath, "Logs").Replace("\\", "/");

        private string SavesFolderPath = Path.Combine(Application.persistentDataPath, "Saves").Replace("\\", "/");

        private string DiscordInviteLink = "https://discord.gg/FnKBMfRqRb";

        public static void Load()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "constants.json");
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                Constants deserializedObject = JsonConvert.DeserializeObject<Constants>(dataAsJson);

                Instance = deserializedObject;
            }
            else
            {
                Debug.LogError("Cannot find constants.json file.");
            }
        }

        public static void Save()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "constants.json");

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using FileStream stream = File.Create(filePath);
                stream.Close();

                File.WriteAllText(filePath, JsonConvert.SerializeObject(Instance, Formatting.Indented));
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }
    }
}