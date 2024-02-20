using System;

namespace com.Halcyon.Core.Interaction.Character.CharacterParameters.Needs
{
    public class CharacterNeeds : CharacterSubscriptor
    {
        public Need Hunger { get; } = new();
        public Need Enjoyment { get; } = new();
        
        protected virtual void UpdateNeeds(float needDecay)
        {
            Hunger.Value -= needDecay;
            Enjoyment.Value -= needDecay;
        }

        public override Action<float> GetActionToSubscribeToOnDecay()
        {
            return UpdateNeeds;
        }
    }
}