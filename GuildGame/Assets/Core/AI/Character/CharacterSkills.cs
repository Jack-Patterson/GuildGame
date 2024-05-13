using System.Collections.Generic;
using com.Halkyon.Input;

namespace com.Halkyon.AI.Character
{
    public class CharacterSkills : CharacterSubscriber
    {
        public List<Skill> Skills { get; private set; } = new();

        private void Start()
        {
            InputActions inputActions = FindObjectOfType<InputActions>();
            inputActions.StrategyPlayer.Mouse2Click.performed += _ =>
            {
                Skills[0].Progress += 10;
                print($"Skill {Skills[0].Name} progress: " + Skills[0].Progress);
            };

            Skills = Skill.BaseSkills;
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
            print("Skills Unsubscribed!");
        }
    }
}