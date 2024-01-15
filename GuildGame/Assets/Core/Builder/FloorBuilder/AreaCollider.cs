using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Builder.FloorBuilder
{
    [RequireComponent(typeof(BoxCollider))]
    public class AreaCollider : ExtendedMonoBehaviour
    {
        internal BoxCollider BoxCollider;

        protected override void OnAwake()
        {
            BoxCollider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Renderer colliderRenderer))
            {
                Log($"Disabling renderer for object {other.gameObject.name}");
                colliderRenderer.enabled = false;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Renderer colliderRenderer))
            {
                Log($"Enabling renderer for object {other.gameObject.name}");
                colliderRenderer.enabled = true;
            }
        }
    }
}