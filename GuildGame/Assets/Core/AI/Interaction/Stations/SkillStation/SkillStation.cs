using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes.Skills;

namespace com.Halkyon.AI.Interaction.Stations.SkillStation
{
    public abstract class SkillStation : InteractableMonoBehaviour
    {
        public List<Skill> ImprovableSkills { get; protected set; } = new();
        private float _improvementTimeInSeconds = 0;

        protected float ImprovementTimeInSeconds
        {
            get => _improvementTimeInSeconds;
            set => _improvementTimeInSeconds = value;
        }


        public abstract override void Interact(Character.Character character);
    }
}