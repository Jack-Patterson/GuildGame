using System.Collections.Generic;
using System.Linq;

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

        public Skill GetLowestSkillForClass()
        {
            return Character.AspiredClass.RequiredSkills.OrderBy(skill => skill.Level).ThenBy(skill => skill.Progress)
                .FirstOrDefault();
        }

        private void OnSkillAdded(Skill skill)
        {
            Skills.Add(skill);
        }

        private void OnSkillRemoved(Skill skill)
        {
            Skills.Remove(skill);
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
        }
    }
}