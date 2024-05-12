using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halkyon.AI.Character
{
    public class Skill
    {
        private static List<Skill> _skills = new List<Skill>();
        private string _name;
        private int _level = 1;
        private float _progress = 0;
        private readonly int _levelProgressIncrement = 20;

        public static List<Skill> BaseSkills => DeepCopySkills();
        public string Name => _name;
        public int Level
        {
            get => _level;
            set => _level = Mathf.Min(100, value);
        }
        public float Progress
        {
            get => _progress;
            set => _progress = Mathf.Min(CalculateLevelProgressAmount(), value);
        }
        
        public Skill(string name)
        {
            _name = name;
        }
        
        public Skill(string name, int levelProgressIncrement)
        {
            _name = name;
            _levelProgressIncrement = levelProgressIncrement;
        }
        
        public Skill(string name, int level, float progress, int levelProgressIncrement)
        {
            _name = name;
            _level = level;
            _progress = progress;
            _levelProgressIncrement = levelProgressIncrement;
        }

        public static void RegisterSkill(Skill skill)
        {
            _skills.Add(skill);
        }

        private static List<Skill> DeepCopySkills()
        {
            return _skills.Select(skill => new Skill(skill.Name, skill._level, skill._progress, skill._levelProgressIncrement)).ToList();
        }
        
        private int CalculateLevelProgressAmount()
        {
            int levelProgressAmount = _level + (_levelProgressIncrement * (_level - 1));
            Debug.Log($"Level Ceiling: {levelProgressAmount}");
            return levelProgressAmount;
        }
    }
}