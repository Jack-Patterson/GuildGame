using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace com.Halcyon.Core.Services.Serialization
{
    public class Constants
    {
        private static string _exampleVariable;
        
        public static string ExampleVariable
        {
            get { return _exampleVariable; }
            private set { _exampleVariable = value; }
        }

        // Method to load and deserialize the constants.json file
        public static void LoadConstants()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "constants.json");
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                var constantsData = JsonConvert.DeserializeObject<ConstantsData>(dataAsJson);

                ExampleVariable = constantsData.ExampleVariable;
            }
            else
            {
                Debug.LogError("Cannot find constants.json file.");
            }
        }
        
        private class ConstantsData
        {
            public string ExampleVariable { get; set; }
        }
    }
}