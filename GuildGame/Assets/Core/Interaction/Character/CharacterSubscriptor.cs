﻿using System;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.Interaction.Character
{
    public abstract class CharacterSubscriptor : LoggerUtil
    {
        public abstract Action<float> GetActionToSubscribeToOnDecay();
    }
}