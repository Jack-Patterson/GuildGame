namespace com.Halkyon.AI.Character.States
{
    public interface ICharacterState
    {
        void Enter();
        void Update();
        void Exit();
        void Reset();
        void UpdateArgs(object[] args);
        string GetDescription();
    }
}