﻿using System;
using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.Attributes.Stats;
using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction;
using com.Halkyon.AI.Interaction.Stations;
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

        public CharacterRank Rank => _rank;
        public List<Need> Needs => _needs.Needs;
        public List<Skill> Skills => _skills.Skills;
        public List<Stat> Stats => _stats.Stats;
        public NavMeshAgent Agent => _agent;
        public CharacterActionHandler ActionHandler => _actionHandler;
        protected CharacterManager CharacterManager => CharacterManager.Instance;

        private void Start()
        {
            _needs = GetComponent<CharacterNeeds>();
            _skills = GetComponent<CharacterSkills>();
            _stats = GetComponent<CharacterStats>();
            _agent = GetComponent<NavMeshAgent>();
            _actionHandler = GetComponent<CharacterActionHandler>();
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