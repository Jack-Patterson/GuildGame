using System;
using System.IO;
using com.Halcyon.API.Core;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Manager;
using Newtonsoft.Json;
using UnityEngine;

namespace com.Halcyon.Core.Services.Serialization
{
    public class JsonDataService: ISerializationService
    {
        public bool SaveData<T>(T objectToSerialize, string relativeSaveLocation, bool encrypted = false)
        {
            string path = Constants.SavesFolderPath + $"/{Utils.AddSuffixIfNotExists(relativeSaveLocation, ".json")}";

            object objectToSerializeConverted = ConvertNonSerializableTypes(objectToSerialize);
            
                try
                {
                    if (File.Exists(path))
                    {
                        GameLogger.Log($"File {relativeSaveLocation} already exists. Overwriting existing file.");
                        File.Delete(path);
                    }
                    else
                    {
                        Debug.Log($"File {relativeSaveLocation} does not exist. Creating new file.");
                    }

                    using FileStream stream = File.Create(path);
                    stream.Close();
                    
                    File.WriteAllText(path, JsonConvert.SerializeObject(objectToSerializeConverted, Formatting.Indented));
                    
                    GameLogger.Log($"Successfully saved all data to {relativeSaveLocation}");
                    return true;
                }
                catch (Exception e)
                {
                    GameLogger.LogException(e);
                    return false;
                }
        }

        public T LoadData<T>(string relativeSaveLocation, bool encrypted = false)
        {
            string path = Constants.SavesFolderPath + $"/{Utils.AddSuffixIfNotExists(relativeSaveLocation, ".json")}";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Cannot find file {relativeSaveLocation}. File does not exist.", relativeSaveLocation);
            }

            try
            {
                T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                
                GameLogger.Log($"Successfully loaded all data from {relativeSaveLocation}");
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object ConvertNonSerializableTypes(object objectToConvert)
        {
            switch (objectToConvert)
            {
                case Vector3 vector:
                    return new SerializableVector3(vector);
                case Quaternion quaternion:
                    return new SerializableQuaternion(quaternion);
            }

            return objectToConvert;
        }
    }
}