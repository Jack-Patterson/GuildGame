using System;
using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.Attributes.Stats;
using com.Halkyon.AI.Character.Classes;
using com.Halkyon.AI.Character.States;
using UnityEngine;
using UnityEngine.AI;

namespace com.Halkyon.AI.Character
{
    [RequireComponent(typeof(CharacterNeeds))]
    [RequireComponent(typeof(CharacterSkills))]
    [RequireComponent(typeof(CharacterStats))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CharacterActionHandler))]
    public class Character : ExtendedMonoBehaviour
    {
        internal Action OnUnsubscribeCharacterEvents;
        [SerializeField] private CharacterRank _rank = CharacterRank.None;
        private CharacterNeeds _needs;
        private CharacterSkills _skills;
        private CharacterStats _stats;
        private NavMeshAgent _agent;
        private CharacterActionHandler _actionHandler;
        private CharacterClass _currentClass;
        private CharacterClass _aspiredClass;

        public CharacterRank Rank => _rank;
        public CharacterNeeds Needs => _needs;
        public CharacterSkills Skills => _skills;
        public CharacterStats Stats => _stats;
        public NavMeshAgent Agent => _agent;
        public CharacterActionHandler ActionHandler => _actionHandler;
        public CharacterClass CurrentClass => _currentClass;
        public CharacterClass AspiredClass => _aspiredClass;
        protected CharacterManager CharacterManager => CharacterManager.Instance;

        private void Start()
        {
            _needs = GetComponent<CharacterNeeds>();
            _skills = GetComponent<CharacterSkills>();
            _stats = GetComponent<CharacterStats>();
            _agent = GetComponent<NavMeshAgent>();
            _actionHandler = GetComponent<CharacterActionHandler>();

            if (_currentClass == null)
            {
                _currentClass = CharacterManager.GetDefaultClass();
                _aspiredClass = _currentClass.NextClasses[0];
            }
        }

        public void Move(Vector3 target)
        {
            _actionHandler.ChangeState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }), forceStateChange: true);
        }

        public void Move(Transform target) => Move(target.position);

        public void IncreaseRank()
        {
            _rank--;
        }

        internal void InvokeUnsubscribeCharacterEvents() => OnUnsubscribeCharacterEvents?.Invoke();

        private void OnDestroy()
        {
            InvokeUnsubscribeCharacterEvents();
        }
    }
}