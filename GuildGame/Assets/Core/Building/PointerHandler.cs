using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class PointerHandler
    {
        private GameObject pointer;

        public PointerHandler(GameObject pointer)
        {
            this.pointer = pointer;
        }

        internal void SetPointerPosition(Vector3 position)
        {
            pointer.transform.position = position;
        }
    }
}