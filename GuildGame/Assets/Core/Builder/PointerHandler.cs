using com.Halcyon.API.Core;
using com.Halcyon.Core.Utils;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    public class PointerHandler
    {
        private readonly GameObject _pointer;
        private Builder _builder;

        internal Vector3 Position
        {
            get => _pointer.transform.position;
            set => _pointer.transform.position = API.Core.Utils.ClampVector3OnlyXZ(value, -Constants.BuilderConstants.MaxGridSize, Constants.BuilderConstants.MaxGridSize);
        }

        public PointerHandler(GameObject pointer, Builder builder)
        {
            _pointer = pointer;
            _builder = builder;

            _builder.BuilderGameStateEnabled += TogglePointerVisibility;
            _builder.BuilderGameStateDisabled += TogglePointerVisibility;
        }

        private void OnMousePositionChanged(RaycastHit hit)
        {
            
        }

        private void TogglePointerVisibility()
        {
            if (_pointer == null) return;
            
            _pointer.SetActive(!_pointer.activeSelf);
        }
    }
}