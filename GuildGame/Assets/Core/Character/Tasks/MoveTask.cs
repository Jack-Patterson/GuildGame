using System.Collections;
using UnityEngine;

namespace com.Halcyon.Core.Character.Tasks
{
    public class MoveTask : Task
    {
        private Vector3 _destination;

        public MoveTask(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            StartTaskCoroutine(MoveToPosition());
        }

        private IEnumerator MoveToPosition()
        {
            Character.SetTarget(_destination);
            yield return null;

            while (!Character.DestinationReached())
            {
                yield return null;
            }

            CompleteTask();
        }

        public override void Reset()
        {
            _destination = default;
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }
    }
}