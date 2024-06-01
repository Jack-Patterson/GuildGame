﻿using System;

namespace com.Halkyon.AI.Character.States
{
    internal class CharacterStateFactory
    {
        public static CharacterState ConstructState<T>(Character character, object[] arguments) where T : CharacterState
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            CharacterState characterState = (CharacterState)Activator
                .CreateInstance(typeof(T), 
                    character, 
                    arguments);

            return characterState;
        }
    }
}