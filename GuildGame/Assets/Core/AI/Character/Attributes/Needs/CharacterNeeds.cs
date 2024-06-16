using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Needs
{
    public class CharacterNeeds : CharacterSubscriber
    {
        private Action _onNeedsDecay;
        private List<Need> _needs = new();

        public List<Need> Needs
        {
            get => _needs;
            protected internal set {

                foreach (Need need in value)
                {
                    need.OnNeedDepleted += OnNeedDepleted;
                    _onNeedsDecay += need.Decay;
                }
                
                _needs = value;
            }
        }

        private void Awake()
        {
            CharacterManager.OnNeedAdded += OnNeedAdded;
            CharacterManager.OnNeedRemoved += OnNeedRemoved;

            StartCoroutine(DecayRoutine());
        }

        public Need GetLowestNeed()
        {
            return Needs.OrderBy(need => need.Value).FirstOrDefault();
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
            _onNeedsDecay = null;

            Needs.ForEach(need => need.OnNeedDepleted = null);
        }

        private IEnumerator DecayRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);

                _onNeedsDecay?.Invoke();
            }
        }

        internal void OnNeedAdded(Need need)
        {
            need.OnNeedDepleted += OnNeedDepleted;
            _onNeedsDecay += need.Decay;
            Needs.Add(need);
        }

        private void OnNeedRemoved(Need need)
        {
            need.OnNeedDepleted = null;
            _onNeedsDecay -= need.Decay;
            Needs.Remove(need);
        }

        private void OnNeedDepleted(Need need)
        {
            print($"Need {need.Name} fully depleted!");
        }
    }
}