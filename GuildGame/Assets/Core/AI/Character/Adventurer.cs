using com.Halkyon.AI.Character.Actions;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.Classes;
using UnityEngine;

namespace com.Halkyon.AI.Character
{
    [RequireComponent(typeof(CharacterNeeds))]
    [RequireComponent(typeof(CharacterSkills))]
    [RequireComponent(typeof(AdventurerActionHandler))]
    public class Adventurer : Character
    {
        
        [SerializeField] private CharacterRank _rank = CharacterRank.None;
        private CharacterNeeds _needs;
        private CharacterSkills _skills;
        private CharacterClass _currentClass;
        private CharacterClass _aspiredClass;

        public new readonly string CharacterType = "Adventurer";
        public CharacterRank Rank => _rank;
        public CharacterNeeds Needs => _needs;
        public CharacterSkills Skills => _skills;
        public CharacterClass CurrentClass => _currentClass;
        public CharacterClass AspiredClass => _aspiredClass;
        public new AdventurerActionHandler ActionHandler => (AdventurerActionHandler) base.ActionHandler;
        
        private new void Start()
        {
            base.Start();
            _needs = GetComponent<CharacterNeeds>();
            _skills = GetComponent<CharacterSkills>();
            
            if (_currentClass == null)
            {
                _currentClass = CharacterManager.GetDefaultClass();
                _aspiredClass = _currentClass.NextClasses[0];
            }
        }
        
        public void IncreaseRank()
        {
            _rank--;
        }
    }
}