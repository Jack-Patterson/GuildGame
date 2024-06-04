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

        public CharacterClassSerializable(string id, string name, List<RequiredSkillData> requiredSkills,
            List<string> nextClasses, List<RequiredItemData> requiredItems)
        {
            Id = id;
            Name = name;
            RequiredSkills = requiredSkills;
            NextClasses = nextClasses;
            RequiredItems = requiredItems;
        }
    }
}