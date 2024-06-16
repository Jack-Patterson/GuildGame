using System.Collections.Generic;
using System.Linq;

namespace com.Halkyon.AI.Character.Attributes.Skills
{
    public class CharacterSkills : CharacterSubscriber
    {
        public List<Skill> Skills { get; protected internal set; } = new();

        private void Awake()
        {
            CharacterManager.OnSkillAdded += OnSkillAdded;
            CharacterManager.OnSkillRemoved += OnSkillRemoved;
        }

        public Skill GetLowestRequiredSkillForAspiredClass()
        {
            return ((Adventurer)Character).AspiredClass?.RequiredSkills.OrderBy(skill => skill.Level).ThenBy(skill => skill.Progress)
                .FirstOrDefault();
        }

        public Skill GetLowestRequiredSkillForAspiredClass(List<Skill> skillsFilter)
        {
            return ((Adventurer)Character).AspiredClass?.RequiredSkills
                .FindAll(skill => skillsFilter.Find(listSkill => listSkill.Id == skill.Id) != null)
                .OrderBy(skill => skill.Level).ThenBy(skill => skill.Progress).FirstOrDefault();
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