using System;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Stats
{
    public class Stat : IAttribute<Stat>
    {
        public Action<Stat> OnStatDepleted;
        private string _name;
        private int _amount = 100;
        private int _maxAmount = 100;

        public string Name => _name;

        public int Amount
        {
            get => _amount;
            set => SetAmount(value);
        }

        public int MaxAmount => _maxAmount;

        public Stat(string name, int maxAmount)
        {
            _name = name;
            _maxAmount = maxAmount;
            _amount = maxAmount;
        }

        private void SetAmount(int value)
        {
            if (value <= 0)
            {
                _amount = 0;
                OnStatDepleted?.Invoke(this);
            }
            else
            {
                _amount = Mathf.Min(100, value);
            }
        }

        public void Reset()
        {
            _amount = _maxAmount;
        }

        public Stat Copy()
        {
            return new Stat(Name, MaxAmount);
        }

        public Stat DeepCopy()
        {
            Stat stat = Copy();
            stat._amount = _amount;

            return stat;
        }

        public override string ToString()
        {
            return $"{_name} : {_amount} : {_maxAmount}";
        }
    }
}