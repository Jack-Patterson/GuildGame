﻿using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Skills
{
    public class Skill : IAttribute<Skill>
    {
        private string _id;
        private string _name;
        private int _level = 1;
        private float _progress = 0;
        private readonly int _levelProgressIncrement;

        public string Id => _id;
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

        public Skill(string id, string name, int levelProgressIncrement)
        {
            _id = id;
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
            return new Skill(_id, _name, _levelProgressIncrement);
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

        public void ProgressSkill()
        {
            SetLevelProgress(LevelProgressIncrement);
        }

        private void SetLevelProgress(float value)
        {
            int levelProgressCeiling = CalculateLevelProgressCeiling();

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

        private int CalculateLevelProgressCeiling()
        {
            int levelProgressAmount = 100 + (_levelProgressIncrement * (_level - 1));
            return levelProgressAmount;
        }
    }
}