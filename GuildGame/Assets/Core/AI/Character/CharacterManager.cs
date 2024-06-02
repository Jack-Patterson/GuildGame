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

        public static Action<Need> OnNeedAdded;
        public static Action<Need> OnNeedRemoved;
        public static Action<Stat> OnStatAdded;
        public static Action<Stat> OnStatRemoved;
        public static Action<Skill> OnSkillAdded;
        public static Action<Skill> OnSkillRemoved;
        public List<Need> Needs => CopyAttributesList(_needs);
        public List<Skill> Skills => CopyAttributesList(_skills);
        public List<Stat> Stats => CopyAttributesList(_stats);

        private List<string> _maleNames = new();
        private List<string> _femaleNames = new();
        private List<string> _genderNeutralLastNames = new();
        private List<string> _maleLastNames = new();
        private List<string> _femaleLastNames = new();
        private readonly List<Need> _needs = new();
        private readonly List<Stat> _stats = new();
        private readonly List<Skill> _skills = new();

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

        private void Start()
        {
            LoadAttribute<Need>("Character/Attributes/Needs");
            LoadAttribute<Skill>("Character/Attributes/Skills");
            LoadAttribute<Stat>("Character/Attributes/Stats");
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

        public void AddAttribute<T>(T attribute) where T : IAttribute<T>
        {
            switch (attribute)
            {
                case Need need:
                    _needs.Add(need);
                    OnNeedAdded?.Invoke(need);
                    break;
                case Skill skill:
                    _skills.Add(skill);
                    OnSkillAdded?.Invoke(skill);
                    break;
                case Stat stat:
                    _stats.Add(stat);
                    OnStatAdded?.Invoke(stat);
                    break;
            }
        }

        public void RemoveAttribute<T>(T attribute) where T : IAttribute<T>
        {
            switch (attribute)
            {
                case Need need:
                    _needs.Remove(need);
                    OnNeedRemoved?.Invoke(need);
                    break;
                case Skill skill:
                    _skills.Remove(skill);
                    OnSkillRemoved?.Invoke(skill);
                    break;
                case Stat stat:
                    _stats.Remove(stat);
                    OnStatRemoved?.Invoke(stat);
                    break;
            }
        }
        
        private void LoadAttribute<T>(string path) where T : IAttribute<T>
        {
            TextAsset file = Resources.Load<TextAsset>(path);
            List<T> attributes = JsonConvert.DeserializeObject<List<T>>(file.text);

            foreach (T attribute in attributes)
            {
                AddAttribute(attribute);
            }
        }

        private List<T> CopyAttributesList<T>(List<T> attributes) where T : IAttribute<T>
        {
            return attributes.Select(attribute => attribute.Copy()).ToList();
        }

        public void ConstructNeed(string needName, int maxValue)
        {
            ConstructNeed(needName, maxValue, 0.01f);
        }

        public void ConstructNeed(string needName, int maxValue, float decayRate)
        {
            object[] args = { needName, maxValue, decayRate };
            Need need = AttributeFactory.ConstructAttribute<Need>(args);
            AddAttribute(need);
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