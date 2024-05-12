using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halkyon.AI.Character
{
    public class Need
    {
        private static List<Need> _needs = new List<Need>();
        private readonly float _decayRate = 0.01f;
        private string _name;
        private float _value;

        public static List<Need> BaseNeeds => DeepCopyNeeds();
        public string Name => _name;
        public float Value
        {
            get => _value;
            set => _value = Mathf.Max(0, value);
        }
        
        public Need(string name, float value)
        {
            _name = name;
            _value = value;
        }
        
        public Need(string name, float value, float decayRate)
        {
            _name = name;
            _value = value;
            _decayRate = decayRate;
        }

        public void Decay()
        {
            Value -= _decayRate;
        }

        public static void RegisterNeed(Need need)
        {
            _needs.Add(need);
        }

        private static List<Need> DeepCopyNeeds()
        {
            return _needs.Select(need => new Need(need.Name, need.Value, need._decayRate)).ToList();
        }
    }
}