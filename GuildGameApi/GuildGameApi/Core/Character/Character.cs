using com.Halcyon.API.Core.Character.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace com.Halcyon.API.Core.Character;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Character : ExtendedMonoBehaviour
{
    private CharacterClass _characterClass = CharacterClass.None;
    protected NavMeshAgent NavMeshAgent = null!;
    protected ICharacterTask CurrentTask = null!;

    public CharacterClass CharacterClass
    {
        get => _characterClass;
        set => _characterClass = value;
    }

    public abstract void SetTarget(Vector3 target);

    public abstract void SetTarget(Transform target);
}