using System;
using com.Halkyon.AI.Character.Attributes;
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
    public class Character : ExtendedMonoBehaviour
    {
        internal Action OnUnsubscribeCharacterEvents;

        internal void InvokeUnsubscribeCharacterEvents() => OnUnsubscribeCharacterEvents?.Invoke();
    }
}