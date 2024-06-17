using System;
using System.Collections.Generic;
using System.Linq;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.Attributes.Stats;
using com.Halkyon.AI.Character.Classes;
using com.Halkyon.AI.Character.StaffJobs;
using com.Halkyon.Items;
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

        private List<string> _maleNames = new();
        private List<string> _femaleNames = new();
        private List<string> _genderNeutralLastNames = new();
        private List<string> _maleLastNames = new();
        private List<string> _femaleLastNames = new();
        private List<CharacterClass> _classes = new();
        private readonly List<Need> _needs = new();
        private readonly List<Stat> _stats = new();
        private readonly List<Skill> _skills = new();

        public List<Need> Needs => CopyAttributesList(_needs);
        public List<Skill> Skills => CopyAttributesList(_skills);
        public List<Stat> Stats => CopyAttributesList(_stats);
        public List<CharacterClass> Classes => _classes;

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

            LoadAttributes<Need>("Character/Attributes/Needs");
            LoadAttributes<Skill>("Character/Attributes/Skills");
            LoadAttributes<Stat>("Character/Attributes/Stats");
            _classes = ReadFromJsonClasses("Character/Classes");
        }

        public void RequestAttributes(Character character)
        {
            if (character is Staff staff)
            {
                staff.Stats.Stats = Stats;
            }
            else if (character is Adventurer adventurer)
            {
                adventurer.Needs.Needs = Needs;
                adventurer.Stats.Stats = Stats;
                adventurer.Skills.Skills = Skills;
            }
        }

        public string GetRandomName(bool isMale) => GetRandomName(isMale, false);

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

        public Skill GetSkillById(string id)
        {
            return _skills.Find(skill => skill.Id == id);
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

        public CharacterClass GetDefaultClass()
        {
            return _classes.Find(characterClass => characterClass.Id == "class_basic");
        }

        private void LoadAttributes<T>(string path) where T : IAttribute<T>
        {
            List<T> attributes = ReadFromJson<T>(path);

            foreach (T attribute in attributes)
            {
                AddAttribute(attribute);
            }
        }

        private List<T> ReadFromJson<T>(string path)
        {
            TextAsset file = Resources.Load<TextAsset>(path);
            return JsonConvert.DeserializeObject<List<T>>(file.text);
        }

        private List<CharacterClass> ReadFromJsonClasses(string path)
        {
            TextAsset file = Resources.Load<TextAsset>(path);
            List<CharacterClassSerializable> characterClassModels =
                JsonConvert.DeserializeObject<List<CharacterClassSerializable>>(file.text);

            return PopulateClassesData(characterClassModels);
        }

        private List<CharacterClass> PopulateClassesData(List<CharacterClassSerializable> characterClassModels)
        {
            List<CharacterClass> classes = new();

            foreach (CharacterClassSerializable characterClassModel in characterClassModels)
            {
                classes.Add(new CharacterClass(characterClassModel.Id, characterClassModel.Name, new(), new(), new()));
            }

            foreach (CharacterClassSerializable characterClassModel in characterClassModels)
            {
                CharacterClass characterClass =
                    classes.Find(characterClass => characterClass.Id == characterClassModel.Id);

                foreach (string requiredClass in characterClassModel.NextClasses)
                {
                    CharacterClass nextClass = classes.Find(nextClass => nextClass.Id == requiredClass);

                    if (nextClass == null)
                    {
                        print($"Class {requiredClass} not found for class {characterClass.Name}!", LogType.Error);
                        continue;
                    }

                    characterClass.NextClasses.Add(nextClass);
                }

                foreach (RequiredSkillData requiredSkillData in characterClassModel.RequiredSkills)
                {
                    Skill skill = _skills.Find(skill => skill.Id == requiredSkillData.Id);

                    if (skill == null)
                    {
                        print($"Skill {requiredSkillData.Id} not found for class {characterClass.Name}!",
                            LogType.Error);
                        continue;
                    }

                    characterClass.RequiredSkills.Add(skill);
                }

                foreach (RequiredItemData requiredItemData in characterClassModel.RequiredItems)
                {
                    Item item = ItemManager.Instance.GetItemById(requiredItemData.Id);

                    if (item == null)
                    {
                        print($"Item {requiredItemData.Id} not found for class {characterClass.Name}!", LogType.Error);
                        continue;
                    }

                    characterClass.RequiredItems.Add((item, requiredItemData.Amount));
                }
            }

            return classes;
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
                print("Male first names not found!", LogType.Error);
            }

            if (femaleNames != null)
            {
                _femaleNames = DeserializeFiles(femaleNames);
            }
            else
            {
                print("Female first names not found!", LogType.Error);
            }

            if (genderNeutralLastNames != null)
            {
                _genderNeutralLastNames = DeserializeFiles(genderNeutralLastNames);
            }
            else
            {
                print("Gender neutral surnames not found!", LogType.Error);
            }

            if (maleLastNames != null)
            {
                _maleLastNames = DeserializeFiles(maleLastNames);
            }
            else
            {
                print("Male surnames not found!", LogType.Error);
            }

            if (femaleLastNames != null)
            {
                _femaleLastNames = DeserializeFiles(femaleLastNames);
            }
            else
            {
                print("Female surnames not found!", LogType.Error);
            }
        }

        private List<string> DeserializeFiles(TextAsset file)
        {
            return JsonConvert.DeserializeObject<List<string>>(file.text);
        }
    }
}