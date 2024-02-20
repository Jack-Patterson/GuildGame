using System.Collections;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.Character.Tasks
{
    public class LookAtTask : Task
    {
        private Vector3 _lookAtTarget;

        public LookAtTask(Interaction.Character.Character character) : base(character)
        {
        }

        public override void Execute()
        {
            StartTaskCoroutine(LookAt());
        }

        private IEnumerator LookAt()
        {
            Vector3 direction = (_lookAtTarget - Character.transform.position).normalized;
            Character.transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            yield return null;

            CompleteTask();
        }

        public override void Reset()
        {
            _lookAtTarget = default;
        }

        public void SetLookPosition(Vector3 lookPosition)
        {
            _lookAtTarget = lookPosition;
        }
    }
}