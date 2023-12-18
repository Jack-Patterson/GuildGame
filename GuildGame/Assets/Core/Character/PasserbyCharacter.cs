using com.Halcyon.API.Core.Character;
using UnityEngine;

namespace com.Halcyon.Core.Character
{
    public class PasserbyCharacter : CharacterBase
    {
        public void SetTarget(Vector3 position)
        {
            NavMeshAgent.SetDestination(position);
        }
    }
}