using UnityEngine;
using UnityEngine.AI;

namespace com.Halkyon.AI.Character
{
    [RequireComponent(typeof(CharacterNeeds))]
    [RequireComponent(typeof(CharacterSkills))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Character : ExtendedMonoBehaviour
    {
    }
}