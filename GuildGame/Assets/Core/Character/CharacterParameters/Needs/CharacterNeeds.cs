using System;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.Character.CharacterParameters.Needs
{
    public class CharacterNeeds : CharacterSubscriptor
    {
        public Need Hunger { get; }
        public Need Enjoyment { get; }

        public CharacterNeeds()
        {
            Hunger = new Need();
            Enjoyment = new Need();
        }
        
        protected virtual void UpdateNeeds()
        {
            float needDecay = Constants.CharacterConstants.CharacterNeedsConstants.BaseNeedDecay;
            
            Hunger.Value = needDecay;
            Enjoyment.Value = needDecay;
        }

        public override Action GetActionToSubscribeToOnDecay()
        {
            return UpdateNeeds;
        }
    }
}