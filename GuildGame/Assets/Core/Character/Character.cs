using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.Core.Character
{
    public class Character : API.Core.Character.Character
    {
        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        public override void SetTarget(Vector3 target)
        {
            NavMeshAgent.SetDestination(target);
        }

        public override void SetTarget(Transform target)
        {
            NavMeshAgent.SetDestination(target.position);
        }
    }
}