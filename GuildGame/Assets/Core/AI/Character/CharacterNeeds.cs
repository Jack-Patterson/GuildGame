using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Halkyon.AI.Character
{
    public class CharacterNeeds : ExtendedMonoBehaviour
    {
        private Action _onNeedsDecay;
        public List<Need> Needs { get; private set; } = new();

        private void Start()
        {
            Needs = Need.BaseNeeds;

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
    }
}