using System;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.AI.Character
{
    public class CharacterManager : LoggerUtilMonoBehaviour
    {
        private void Start()
        {
            Need.RegisterNeed(new Need("Hunger", 1f, 0.002f));
            Need.RegisterNeed(new Need("Thirst", 1f, 0.003f));
            
            Skill.RegisterSkill(new Skill("Cooking"));
            Skill.RegisterSkill(new Skill("Fishing", 25));
            Skill.RegisterSkill(new Skill("Hunting"));
            Skill.RegisterSkill(new Skill("Mining"));
            Skill.RegisterSkill(new Skill("Smithing", 30));
            Skill.RegisterSkill(new Skill("Woodcutting", 10));
            Skill.RegisterSkill(new Skill("Farming", 15));
        }
    }
}