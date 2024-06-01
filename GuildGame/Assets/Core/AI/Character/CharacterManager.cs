using System;
using System.Collections.Generic;
using System.Linq;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.Attributes.Stats;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.Halkyon.AI.Character
{
    public class CharacterManager : ExtendedMonoBehaviour
    {
        public static CharacterManager Instance { get; private set; }

        private List<string> _maleNames = new List<string>();
        private List<string> _femaleNames = new List<string>();
        private List<string> _genderNeutralLastNames = new List<string>();
        private List<string> _maleLastNames = new List<string>();
        private List<string> _femaleLastNames = new List<string>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            LoadNames();
        }

        public Need ConstructNeed(string name, float value, float decayRate)
        {
            Need need = new Need(name, value, decayRate);
            Need.RegisterNeed(need);
            
            return need;
        }

        public string GetRandomName(bool isMale, bool shouldHaveLastName)
        {
            string firstName = isMale
                ? _maleNames[Random.Range(0, _maleNames.Count)]
                : _femaleNames[Random.Range(0, _femaleNames.Count)];

            List<string> maleLastNames = _maleLastNames.Concat(_genderNeutralLastNames).ToList();
            List<string> femaleLastNames = _femaleLastNames.Concat(_genderNeutralLastNames).ToList();
            string lastName = shouldHaveLastName
                ? (isMale
                    ? maleLastNames[Random.Range(0, maleLastNames.Count)]
                    : femaleLastNames[Random.Range(0, femaleLastNames.Count)])
                : "";

            return (firstName + " " + lastName).Trim();
        }

        private void LoadNames()
        {
            TextAsset maleNames = Resources.Load<TextAsset>("Names/character_names_male");
            TextAsset femaleNames = Resources.Load<TextAsset>("Names/character_names_female");
            TextAsset genderNeutralLastNames = Resources.Load<TextAsset>("Names/character_surnames_neutral");
            TextAsset maleLastNames = Resources.Load<TextAsset>("Names/character_surnames_male");
            TextAsset femaleLastNames = Resources.Load<TextAsset>("Names/character_surnames_female");

            if (maleNames != null)
            {
                _maleNames = DeserializeFiles(maleNames);
            }
            else
            {
                print("Male first names not found!");
            }

            if (femaleNames != null)
            {
                _femaleNames = DeserializeFiles(femaleNames);
            }
            else
            {
                print("Female first names not found!");
            }

            if (genderNeutralLastNames != null)
            {
                _genderNeutralLastNames = DeserializeFiles(genderNeutralLastNames);
            }
            else
            {
                print("Gender neutral surnames not found!");
            }

            if (maleLastNames != null)
            {
                _maleLastNames = DeserializeFiles(maleLastNames);
            }
            else
            {
                print("Male surnames not found!");
            }

            if (femaleLastNames != null)
            {
                _femaleLastNames = DeserializeFiles(femaleLastNames);
            }
            else
            {
                print("Female surnames not found!");
            }
        }

        private List<string> DeserializeFiles(TextAsset file)
        {
            return JsonConvert.DeserializeObject<List<string>>(file.text);
        }
    }
}