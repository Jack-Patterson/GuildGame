using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Character
{
    public class BoundTrigger: ExtendedMonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                // character.SetTarget();
            }
        }
    }
}