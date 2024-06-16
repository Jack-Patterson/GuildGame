using System;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Stats
{
    public class Stat : IAttribute<Stat>
    {
        public Action<Stat> OnStatDepleted;
        private string _name;
        private int _value = 100;
        private int _maxValue = 100;

        public string Name => _name;

        public int Value
        {
            get => _value;
            set => SetAmount(value);
        }

        public int MaxValue => _maxValue;

        public Stat(string name, int maxValue)
        {
            _name = name;
            _maxValue = maxValue;
            _value = maxValue;
        }

        private void SetAmount(int value)
        {
            if (value <= 0)
            {
                _value = 0;
                OnStatDepleted?.Invoke(this);
            }
            else
            {
                _value = Mathf.Min(100, value);
            }
        }

        public void Reset()
        {
            _value = _maxValue;
        }

        public Stat Copy()
        {
            return new Stat(Name, MaxValue);
        }

        public Stat DeepCopy()
        {
            Stat stat = Copy();
            stat._value = _value;

            return stat;
        }

        public override string ToString()
        {
            return $"{_name} : {_value} : {_maxValue}";
        }
    }
}