using System;
using com.Halcyon.Core.Character.CharacterParameters.Needs;
using com.Halcyon.Core.Character.CharacterParameters.Stats;
using com.Halcyon.Core.Character.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.Core.Character
{
    [RequireComponent(typeof(TaskHandler))]
    public class Character : API.Core.Character.Character
    {
        protected TaskHandler TaskHandler = null!;
        internal event Action<float> OnNeedsDecay = null!;

        public Vector3 Velocity
        {
            get => Agent.velocity;
            set => Agent.velocity = value;
        }
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            TaskHandler = GetComponent<TaskHandler>();
        }

        protected override void OnUpdate()
        {
            float needDecay = Constants.CharacterConstants.CharacterNeedsConstants.BaseNeedDecay * Time.deltaTime;
            OnNeedsDecay?.Invoke(needDecay);
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
            Velocity = Vector3.zero;
        }
    }
    
    public class Character<TStats> : Character where TStats : CharacterStats, new()
    {
        protected TStats Stats { get; private set; }

        protected void Start()
        {
            InitializeStats(new TStats());
        }
        
        private void InitializeStats(TStats stats)
        {
            Stats = stats;
        }
    }
    
    public class Character<TNeeds, TStats> : Character<TStats> where TNeeds : CharacterNeeds, new() where TStats : CharacterStats, new()
    {
        protected TNeeds Needs { get; private set; }

        protected new void Start()
        {
            base.Start();
            
            InitializeNeeds(new TNeeds());
        }
        
        private void InitializeNeeds(TNeeds needs)
        {
            Needs = needs;
            
            OnNeedsDecay += Needs.GetActionToSubscribeToOnDecay();
        }
    }
}