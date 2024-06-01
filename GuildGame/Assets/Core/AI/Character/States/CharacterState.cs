using System;
using com.Halkyon.Services.Logger;

namespace com.Halkyon.AI.Character.States
{
    public abstract class CharacterState : LoggerServiceUser, ICharacterState
    {
        protected readonly Character Character;
        protected object[] Arguments;


        public CharacterState(Character character, object[] args)
        {
            Character = character;
            Arguments = args;
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();

        public void UpdateArgs(object[] args)
        {
            Arguments = args;
        }

        public static CharacterState ConstructState<T>(Character character, object[] arguments)
            where T : CharacterState =>
            CharacterStateFactory.ConstructState<T>(character, arguments);

        public static CharacterState ConstructState<T>(Character character) where T : CharacterState =>
            ConstructState<T>(character, null);
    }
}