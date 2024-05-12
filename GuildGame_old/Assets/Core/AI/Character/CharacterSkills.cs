using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Manager;

namespace com.Halcyon.Core.AI.Character
{
    public class CharacterSkills : LoggerUtilMonoBehaviour
    {
        public List<Skill> Skills { get; private set; } = new();

        private void Awake()
        {
            GameInitializer.GameInitializationComplete += () =>
            {
                GameManager.Instance.GameParameters.InputService.TimeOneSpeedPressStarted += () =>
                {
                    Skills[0].Progress += 10;
                    print("Skill 1 progress: " + Skills[0].Progress);
                };
                print("Game initialization complete");
            };
            print("CharacterSkills added");
        }

        private void Start()
        {
            Skills = Skill.BaseSkills;
        }
    }
}