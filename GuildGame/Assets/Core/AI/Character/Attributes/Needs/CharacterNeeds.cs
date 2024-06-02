using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Needs
{
    public class CharacterNeeds : CharacterSubscriber
    {
        private Action _onNeedsDecay;
        internal List<Need> Needs { get; } = new();

        private void Awake()
        {
            CharacterManager.OnNeedAdded += OnNeedAdded;
            CharacterManager.OnNeedRemoved += OnNeedRemoved;
            
            StartCoroutine(DecayRoutine());
        }
        
        private void Start()
        {
            foreach (Need need in Needs)
            {
                print(need);
            }
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
            _onNeedsDecay = null;

            Needs.ForEach(need => need.OnNeedDepleted = null);
            print("Needs Unsubscribed!");
        }

        private IEnumerator DecayRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);

                _onNeedsDecay?.Invoke();
            }
        }

        private void OnNeedAdded(Need need)
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