using com.Halcyon.Core.Utils;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats
{
    public class Stat
    {
        private float _value;
        
        public float Value
        {
            get => _value;
            set => _value = Mathf.Clamp(value, Constants.CharacterConstants.CharacterStatsConstants.MinValue, Constants.CharacterConstants.CharacterStatsConstants.MaxValue);
        }

        public Stat()
        {
            Value = Constants.CharacterConstants.CharacterStatsConstants.BaseValue;
        }
        
        public Stat(float value)
        {
            Value = value;
        }
    }
}