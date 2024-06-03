using System.Collections.Generic;

namespace com.Halkyon.AI.Character.Classes
{
    internal class CharacterClassSerializable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<RequiredSkillData> RequiredSkills { get; set; }
        public List<string> NextClasses { get; set; }
        public List<RequiredItemData> RequiredItems { get; set; }
    }
}