using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.Core.AI.Character
{
    [RequireComponent(typeof(CharacterNeeds))]
    [RequireComponent(typeof(CharacterSkills))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Character : MonoBehaviour
    {
        public bool IsStaff { get; internal set; }
    }
}