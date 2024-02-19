using com.Halcyon.API.Core.Character.CharacterTasks;
using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.API.Core.Character;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Character : ExtendedMonoBehaviour
{
    private CharacterClass _characterClass = CharacterClass.None;
    protected NavMeshAgent Agent = null!;

    public CharacterClass CharacterClass
    {
        get => _characterClass;
        set => _characterClass = value;
    }

    public abstract void SetTarget(Vector3 target);

    public abstract void SetTarget(Transform target);

    public abstract bool DestinationReached();
}