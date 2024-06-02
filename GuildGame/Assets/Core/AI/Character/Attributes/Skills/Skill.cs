using com.Halkyon.Utils;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Skills
{
    public class Skill : IAttribute<Skill>, IDeepCopyable<Skill>
    {
        private string _name;
        private int _level = 1;
        private float _progress = 0;
        private readonly int _levelProgressIncrement = 20;

        public string Name => _name;
        public int LevelProgressIncrement => _levelProgressIncrement;

        public int Level
        {
            get => _level;
            set => _level = Mathf.Min(100, value);
        }

        public float Progress
        {
            get => _progress;
            set => SetLevelProgress(value);
        }

        public Skill(string name, int levelProgressIncrement)
        {
            _name = name;
            _levelProgressIncrement = levelProgressIncrement;
        }

        public void Reset()
        {
            _level = 0;
            _progress = 0;
        }

        public Skill Copy()
        {
            return new Skill(_name, _levelProgressIncrement);
        }

        public Skill DeepCopy()
        {
            Skill skill = Copy();
            skill.Level = _level;
            skill.Progress = _progress;

            return skill;
        }

        public override string ToString()
        {
            return $"{_name} : {_level} : {_progress} : {_levelProgressIncrement}";
        }

        private void SetLevelProgress(float value)
        {
            int levelProgressCeiling = CalculateLevelProgressAmount();

            if (value >= levelProgressCeiling)
            {
                _progress = 0;
                _level++;
            }
            else
            {
                _progress = value;
            }
        }

        private int CalculateLevelProgressAmount()
        {
            int levelProgressAmount = 100 + (_levelProgressIncrement * (_level - 1));
            return levelProgressAmount;
        }
    }
}