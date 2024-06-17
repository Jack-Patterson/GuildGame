using System;
using com.Halkyon.AI.Character.Actions;
using com.Halkyon.AI.Character.Attributes.Stats;
using com.Halkyon.AI.Character.States;
using UnityEngine;
using UnityEngine.AI;

namespace com.Halkyon.AI.Character
{
    [RequireComponent(typeof(CharacterStats))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CharacterActionHandler))]
    public abstract class Character : ExtendedMonoBehaviour
    {
        internal Action OnUnsubscribeCharacterEvents;
        private string _name;
        private CharacterStats _stats;
        private NavMeshAgent _agent;
        private CharacterActionHandler _actionHandler;

        public abstract string CharacterId { get; }
        public abstract string CharacterType { get; }
        public string Name => _name;
        public CharacterStats Stats => _stats;
        public NavMeshAgent Agent => _agent;
        public CharacterActionHandler ActionHandler => _actionHandler;
        protected CharacterManager CharacterManager => CharacterManager.Instance;

        protected void Awake()
        {
            _stats = GetComponent<CharacterStats>();
            _agent = GetComponent<NavMeshAgent>();
            _actionHandler = GetComponent<CharacterActionHandler>();
        }
        
        protected void Start()
        {
            _name = CharacterManager.GetRandomName(true);
        }

        public void Move(Vector3 target)
        {
            _actionHandler.ChangeState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }), forceStateChange: true);
        }

        public void Move(Transform target) => Move(target.position);

        internal void InvokeUnsubscribeCharacterEvents() => OnUnsubscribeCharacterEvents?.Invoke();

        private void OnDestroy()
        {
            InvokeUnsubscribeCharacterEvents();
        }
    }
}