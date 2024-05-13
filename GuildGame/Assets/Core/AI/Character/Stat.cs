using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halkyon.AI.Character
{
    public class Stat
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
    }
}