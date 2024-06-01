using System;
using com.Halkyon.Services.Logger;

namespace com.Halkyon.AI.Character.States
{
    public abstract class CharacterState : LoggerServiceUser, ICharacterState
    {
        public Action OnStateExit;
        protected Character Character;
        
        public CharacterState(Character character)
        {
            Character = character;
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
        
        protected void InvokeOnStateExit()
        {
            OnStateExit?.Invoke();
        }

        public static CharacterState ConstructState<T>(Character character) where T : CharacterState
        {
            return CharacterStateFactory.ConstructState<T>(character);
        }
    }
}