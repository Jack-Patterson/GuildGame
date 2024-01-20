using System.Collections.Generic;
using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Builder.FloorBuilder
{
    [RequireComponent(typeof(BoxCollider))]
    public class AreaCollider : ExtendedMonoBehaviour
    {
        internal BoxCollider BoxCollider;
        private readonly List<Renderer> _renderersInCollider = new List<Renderer>();

        protected override void OnAwake()
        {
            BoxCollider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!enabled) return;
            
            if (other.gameObject.TryGetComponent(out Renderer colliderRenderer))
            {
                Log($"Disabling renderer for object {other.gameObject.name}");
                _renderersInCollider.Add(colliderRenderer);
                colliderRenderer.enabled = false;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Renderer colliderRenderer))
            {
                Log($"Enabling renderer for object {other.gameObject.name}");
                _renderersInCollider.Remove(colliderRenderer);
                colliderRenderer.enabled = true;
            }
        }
        
        internal void EnableAllRenderers()
        {
            foreach (Renderer rendererInCollider in _renderersInCollider)
            {
                Log($"Enabling renderer for object {rendererInCollider.gameObject.name}");
                rendererInCollider.enabled = true;
            }
        }
    }
}