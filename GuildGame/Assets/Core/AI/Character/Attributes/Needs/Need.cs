using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Needs
{
    public class Need : IAttribute<Need>
    {
        public Action<Need> OnNeedDepleted;
        private static List<Need> _needs = new List<Need>();
        private readonly float _decayRate = 0.01f;
        private string _name;
        private float _value;

        public static List<Need> BaseNeeds => DeepCopyNeeds();
        public string Name => _name;
        public float Value
        {
            get => _value;
            set
            {
                if (value <= 0)
                {
                    _value = 0;
                    OnNeedDepleted?.Invoke(this);
                }
                else
                {
                    _value = Mathf.Min(100, value);
                }
            }
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

        public void Register()
        {
            throw new NotImplementedException();
        }

        public void Register(Need attribute)
        {
            throw new NotImplementedException();
        }

        public Need DeepCopy()
        {
            throw new NotImplementedException();
        }
        
        public override string ToString()
        {
            return $"{Name}: {Value}, Decay Rate: {_decayRate}";
        }
    }
}