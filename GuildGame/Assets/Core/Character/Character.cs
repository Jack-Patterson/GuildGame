using System;
using com.Halcyon.Core.Character.CharacterParameters.Needs;
using com.Halcyon.Core.Character.CharacterParameters.Stats;
using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.Core.Character
{
    [RequireComponent(typeof(TaskHandler))]
    public class Character : API.Core.Character.Character
    {
        protected TaskHandler TaskHandler = null!;
        internal event Action OnNeedsDecay = null!;
        protected CharacterNeeds Needs;
        protected CharacterStats Stats;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            TaskHandler = GetComponent<TaskHandler>();
        }

        protected override void OnFixedUpdate()
        {
            OnNeedsDecay?.Invoke();
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
    
    public class Character<TNeeds, TStats> : Character where TNeeds : CharacterNeeds, new() where TStats : CharacterStats, new()
    {
        public new TNeeds Needs
        {
            get => (TNeeds)base.Needs;
            protected set => base.Needs = value;
        }

        public new TStats Stats
        {
            get => (TStats)base.Stats;
            protected set => base.Stats = value;
        }

        protected void Start()
        {
            InitializeNeedsAndStats(new TNeeds(), new TStats());
        }
        
        protected void InitializeNeedsAndStats(TNeeds needs, TStats stats)
        {
            Needs = needs;
            Stats = stats;
            
            OnNeedsDecay += Needs.GetActionToSubscribeToOnDecay();
        }
    }
}