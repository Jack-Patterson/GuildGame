using System;
using System.Collections.Generic;

namespace com.Halkyon.AI.Character.Attributes.Skills
{
    public class CharacterSkills : CharacterSubscriber
    {
        public List<Skill> Skills { get; } = new();

        private void Awake()
        {
            CharacterManager.OnSkillAdded += OnSkillAdded;
            CharacterManager.OnSkillRemoved += OnSkillRemoved;
        }

        private void Start()
        {
            foreach (Skill skill in Skills)
            {
                print(skill);
            }
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
            print("Skills Unsubscribed!");
        }

        private void OnSkillAdded(Skill skill)
        {
            Skills.Add(skill);
        }

        private void OnSkillRemoved(Skill skill)
        {
            Skills.Remove(skill);
        }
    }
}