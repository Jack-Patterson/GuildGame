using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.API.Core.Character;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class CharacterBase : ExtendedMonoBehaviour
{
    private CharacterClass _characterClass = CharacterClass.None;
    protected NavMeshAgent NavMeshAgent = null!;

    public CharacterClass CharacterClass
    {
        get => _characterClass;
        set => _characterClass = value;
    }

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
}