﻿using System;

namespace com.Halkyon.AI.Character
{
    public abstract class CharacterSubscriber : ExtendedMonoBehaviour
    {
        protected void OnEnable()
        {
            SubscribeOnUnsubscribeCharacterEvent();
        }

        protected void SubscribeOnUnsubscribeCharacterEvent()
        {
            Character character = GetComponent<Character>();
            
            character.OnUnsubscribeCharacterEvents += OnUnsubscribeCharacterEvent;
        }

        protected abstract void OnUnsubscribeCharacterEvent();
    }
}