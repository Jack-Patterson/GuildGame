using System;
using System.Collections.Generic;
using System.Linq;
using com.Halkyon.Utils;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Stats
{
    public class Stat : IAttribute<Stat>, IDeepCopyable<Stat>
    {
        public Action<Stat> OnStatDepleted;
        private static List<Stat> _stats = new List<Stat>();
        private string _name;
        private int _amount = 100;

        public static List<Stat> BaseStats => DeepCopyStats();
        public string Name => _name;

        public int Amount
        {
            get => _amount;
            set
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
        }

        public Stat(string name)
        {
            _name = name;
        }

        public Stat(string name, int amount)
        {
            _name = name;
            _amount = amount;
        }

        public static void RegisterStat(Stat skill)
        {
            _stats.Add(skill);
        }

        private static List<Stat> DeepCopyStats()
        {
            return _stats.Select(stat => new Stat(stat.Name, stat.Amount)).ToList();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }

        public void Register(Stat attribute)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public Stat Copy()
        {
            throw new NotImplementedException();
        }

        public Stat DeepCopy()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{_name}: {_amount}";
        }
    }
}