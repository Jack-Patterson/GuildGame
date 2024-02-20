using UnityEngine;

namespace com.Halcyon.Core.Character.CharacterParameters.Needs
{
    public class Need
    {
        private float _value;
        
        public float Value
        {
            get => _value;
            set => _value = Mathf.Clamp(value, Constants.CharacterConstants.CharacterNeedsConstants.MinValue, Constants.CharacterConstants.CharacterNeedsConstants.MaxValue);
        }

        public Need()
        {
            Value = Constants.CharacterConstants.CharacterNeedsConstants.BaseValue;
        }
        
        public Need(float value)
        {
            Value = value;
        }
    }
}