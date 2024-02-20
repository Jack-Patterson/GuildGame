using System;

namespace com.Halcyon.Core.Character.CharacterParameters.Needs
{
    public class CharacterNeeds : CharacterSubscriptor
    {
        protected virtual void UpdateNeeds(float needDecay)
        {
        }

        public override Action<float> GetActionToSubscribeToOnDecay()
        {
            return UpdateNeeds;
        }
    }
}