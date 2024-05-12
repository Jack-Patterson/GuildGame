namespace com.Halkyon.AI.Character
{
    public class CharacterManager : ExtendedMonoBehaviour
    {
        private void Start()
        {
            Need.RegisterNeed(new Need("Hunger", 1f, 0.002f));
            Need.RegisterNeed(new Need("Thirst", 1f, 0.003f));
            
            Skill.RegisterSkill(new Skill("Cooking", 2, 0, 25));
            Skill.RegisterSkill(new Skill("Fishing", 25));
            Skill.RegisterSkill(new Skill("Hunting"));
            Skill.RegisterSkill(new Skill("Mining"));
            Skill.RegisterSkill(new Skill("Smithing", 30));
            Skill.RegisterSkill(new Skill("Woodcutting", 10));
            Skill.RegisterSkill(new Skill("Farming", 15));
        }
    }
}