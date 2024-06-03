using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.Items;

namespace com.Halkyon.AI.Character.Classes
{
    public class CharacterClass
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public List<Skill> RequiredSkills { get; private set; }
        public List<CharacterClass> NextClasses { get; private set; }
        public List<(Item item, int amount)> RequiredItems { get; private set; }
        
        public CharacterClass(string id, string name, List<Skill> requiredSkills, List<CharacterClass> nextClasses, List<(Item, int)> requiredItems)
        {
            Id = id;
            Name = name;
            RequiredSkills = requiredSkills;
            NextClasses = nextClasses;
            RequiredItems = requiredItems;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {RequiredSkills.Count} - {NextClasses.Count} - {RequiredItems.Count}";
        }
    }
}