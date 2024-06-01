using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Halkyon.AI.Character.Attributes.Needs
{
    public class CharacterNeeds : CharacterSubscriber
    {
        private Action _onNeedsDecay;
        internal List<Need> Needs { get; private set; } = new();

        private void Start()
        {
            Needs = Need.BaseNeeds;

            SubscribeToNeedEvents();
            RegisterOnNeedsDecay();
            StartCoroutine(DecayRoutine());
        }

        private IEnumerator DecayRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);

                _onNeedsDecay?.Invoke();
            }
        }

        private void RegisterOnNeedsDecay()
        {
            foreach (Need need in Needs)
            {
                _onNeedsDecay += need.Decay;
            }
        }

        private void SubscribeToNeedEvents()
        {
            foreach (Need need in Needs)
            {
                need.OnNeedDepleted += OnNeedDepleted;
            }
        }
        
        private void OnNeedDepleted(Need need)
        {
            print($"Need {need.Name} fully depleted!");
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
            _onNeedsDecay = null;

            Needs.ForEach(need => need.OnNeedDepleted = null);
            print("Needs Unsubscribed!");
        }
    }
}