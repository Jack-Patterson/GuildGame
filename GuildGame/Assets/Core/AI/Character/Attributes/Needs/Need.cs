using System;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Needs
{
    public class Need : IAttribute<Need>
    {
        public Action<Need> OnNeedDepleted;
        private readonly float _decayRate;
        private readonly string _name;
        private readonly float _maxValue;
        private float _value;

        public string Name => _name;
        public float MaxValue => _maxValue;
        public float DecayRate => _decayRate;

        public float Value
        {
            get => _value;
            set => SetValue(value);
        }

        public Need(string name, float maxValue, float decayRate = 0.01f)
        {
            _name = name;
            _value = maxValue;
            _maxValue = maxValue;
            _decayRate = decayRate;
        }

        public void Decay()
        {
            Value -= _decayRate;
        }

        public void Reset()
        {
            _value = _maxValue;
        }

        public Need Copy()
        {
            return new Need(Name, MaxValue, DecayRate);
        }

        public Need DeepCopy()
        {
            Need need = Copy();
            need._value = _value;

            return need;
        }

        public override string ToString()
        {
            return $"{Name} : {Value} : {MaxValue} : {DecayRate}";
        }

        private void SetValue(float value)
        {
            if (_value <= 0)
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
}