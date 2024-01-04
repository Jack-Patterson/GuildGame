using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    public class PointerHandler
    {
        private readonly GameObject _pointer;
        private Core.Builder.Builder _builder;

        public PointerHandler(GameObject pointer, Core.Builder.Builder builder)
        {
            _pointer = pointer;
            _builder = builder;

            _builder.BuilderGameStateEnabled += TogglePointerVisibility;
            _builder.BuilderGameStateDisabled += TogglePointerVisibility;
        }

        internal void SetPointerPosition(Vector3 position)
        {
            _pointer.transform.position = position;
        }

        private void TogglePointerVisibility()
        {
            _pointer.SetActive(!_pointer.activeSelf);
        }
    }
}