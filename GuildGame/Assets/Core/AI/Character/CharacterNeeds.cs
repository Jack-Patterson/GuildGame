using System;
using System.Collections;
using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Utils;
using UnityEngine;

namespace com.Halcyon.Core.AI.Character
{
    public class CharacterNeeds : LoggerUtilMonoBehaviour
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
                yield return new WaitForSeconds(Constants.CharacterConstants.CharacterNeedsConstants
                    .NeedsDecayWaitDuration);

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