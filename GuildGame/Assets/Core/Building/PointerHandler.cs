using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class PointerHandler
    {
        private GameObject pointer;
        private Builder _builder;

        public PointerHandler(GameObject pointer, Builder builder)
        {
            this.pointer = pointer;
            _builder = builder;

            _builder.BuilderGameStateEnabled += TogglePointerVisibility;
            _builder.BuilderGameStateDisabled += TogglePointerVisibility;
        }

        internal void SetPointerPosition(Vector3 position)
        {
            pointer.transform.position = position;
        }

        private void TogglePointerVisibility()
        {
            pointer.SetActive(!pointer.activeSelf);
        }
    }
}