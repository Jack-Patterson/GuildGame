using com.Halkyon.AI.Character.Attributes;

namespace com.Halkyon.AI.Character
{
    public class CharacterManager : ExtendedMonoBehaviour
    {
        private void Awake()
        {
            Need.RegisterNeed(new Need("Hunger", 1f, 0.002f));
            Need.RegisterNeed(new Need("Thirst", 1f, 0.003f));
            
            Skill.RegisterSkill(new Skill("Cooking", 1, 0, 25));
            Skill.RegisterSkill(new Skill("Fishing", 25));
            Skill.RegisterSkill(new Skill("Hunting"));
            Skill.RegisterSkill(new Skill("Mining"));
            Skill.RegisterSkill(new Skill("Smithing", 30));
            Skill.RegisterSkill(new Skill("Woodcutting", 10));
            Skill.RegisterSkill(new Skill("Farming", 15));
            
            Stat.RegisterStat(new Stat("Health"));
            Stat.RegisterStat(new Stat("Stamina"));
            Stat.RegisterStat(new Stat("Mana"));
            Stat.RegisterStat(new Stat("Strength"));
            Stat.RegisterStat(new Stat("Agility"));
            Stat.RegisterStat(new Stat("Intelligence"));
        }
    }
}