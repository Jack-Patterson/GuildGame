using System;
using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes;
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
        private CharacterRank _rank = CharacterRank.F;
        private CharacterNeeds _needs;
        private CharacterSkills _skills;
        private CharacterStats _stats;
        private NavMeshAgent _agent;
        private CharacterActionHandler _actionHandler;

        public CharacterRank Rank => _rank;
        public List<Need> Needs => _needs.Needs;
        public List<Skill> Skills => _skills.Skills;
        public List<Stat> Stats => _stats.Stats;
        public NavMeshAgent Agent => _agent;
        public CharacterActionHandler ActionHandler => _actionHandler;

        private void Start()
        {
            _needs = GetComponent<CharacterNeeds>();
            _skills = GetComponent<CharacterSkills>();
            _stats = GetComponent<CharacterStats>();
            _agent = GetComponent<NavMeshAgent>();
            _actionHandler = GetComponent<CharacterActionHandler>();

            Move(new Vector3(10, 0, 10));

            Vector3 target = new Vector3(0, 0, 10);
            _actionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }));
            target = new Vector3(0, 0, 10);
            _actionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }));
            target = new Vector3(10, 0, 0);
            _actionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }));
            target = new Vector3(-10, 0, 10);
            _actionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }));
        }

        public void Move(Vector3 target)
        {
            _actionHandler.ChangeState(CharacterState.ConstructState<CharacterStateMove>(this,
                new[] { (object)target }));
        }

        public void Move(Transform target) => Move(target.position);

        internal void InvokeUnsubscribeCharacterEvents() => OnUnsubscribeCharacterEvents?.Invoke();

        private void OnDestroy()
        {
            InvokeUnsubscribeCharacterEvents();
        }
    }
}