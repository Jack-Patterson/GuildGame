using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.Core.Character
{
    [RequireComponent(typeof(TaskHandler))]
    public class Character : API.Core.Character.Character
    {
        protected TaskHandler TaskHandler = null!;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            TaskHandler = GetComponent<TaskHandler>();
        }
        
        public override void SetTarget(Vector3 target)
        {
            Agent.ResetPath();
            Agent.SetDestination(target);
        }

        public override void SetTarget(Transform target)
        {
            Agent.ResetPath();
            Agent.SetDestination(target.position);
        }

        public override bool DestinationReached()
        {
            return Agent.remainingDistance <= Agent.stoppingDistance;
        }
        
        public void Stop()
        {
            Agent.velocity = Vector3.zero;
        }
    }
}