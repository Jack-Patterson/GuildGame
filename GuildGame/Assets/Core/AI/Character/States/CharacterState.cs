using com.Halkyon.Services.Logger;
using com.Halkyon.Utils;
using UnityEngine;

namespace com.Halkyon.AI.Character.States
{
    public abstract class CharacterState : LoggerUser, ICharacterState
    {
        protected readonly Character Character;
        protected object[] Arguments;
        protected CoroutineRunner CoroutineRunner;

        public CharacterState(Character character, object[] args)
        {
            Character = character;
            Arguments = args;
            CoroutineRunner = Object.FindObjectOfType<CoroutineRunner>();
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();

        public virtual void Reset()
        {
        }

        public abstract string GetDescription();

        public void UpdateArgs(object[] args)
        {
            Arguments = args;
        }

        public static TState ConstructState<TState, TCharacter>(TCharacter character, object[] arguments)
            where TState : CharacterState where TCharacter : Character =>
            CharacterStateFactory.ConstructState<TState>(character, arguments);

        public static TState ConstructState<TState, TCharacter>(TCharacter character) where TState : CharacterState where TCharacter : Character =>
            ConstructState<TState, Character>(character, null);
        
        public static T ConstructState<T>(Character character, object[] arguments)
            where T : CharacterState =>
            ConstructState<T, Character>(character, arguments);
        
        public static T ConstructState<T>(Character character)
            where T : CharacterState =>
            ConstructState<T, Character>(character, null);
    }
}