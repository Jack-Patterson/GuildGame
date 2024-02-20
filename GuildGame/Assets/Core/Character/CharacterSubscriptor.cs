using System;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.Character
{
    public abstract class CharacterSubscriptor : LoggerUtil
    {
        public abstract Action GetActionToSubscribeToOnDecay();
    }
}