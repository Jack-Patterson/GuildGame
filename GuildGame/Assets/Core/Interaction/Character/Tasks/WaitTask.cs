﻿using System.Collections;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.Character.Tasks
{
    public class WaitTask : Task
    {
        private float _timeToWait;

        public WaitTask(Interaction.Character.Character character) : base(character)
        {
        }

        public override void Execute()
        {
            StartTaskCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(_timeToWait);

            CompleteTask();
        }

        public override void Reset()
        {
            _timeToWait = 0;
        }

        public void SetWaitTime(float timeToWait)
        {
            _timeToWait = timeToWait;
        }
    }
}