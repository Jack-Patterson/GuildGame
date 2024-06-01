using System;

namespace com.Halkyon.AI.Character.States
{
    public interface ICharacterState
    {
        void Enter();
        void Update();
        void Exit();
        void UpdateArgs(object[] args);
    }
}