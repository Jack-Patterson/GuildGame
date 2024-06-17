using com.Halkyon.AI.Character.StaffJobs;

namespace com.Halkyon.AI.Character.States
{
    public abstract class StaffState : CharacterState
    {
        public new Staff Character => (Staff)base.Character;

        public StaffState(Staff character, object[] args) : base(character, args)
        {
        }

        public abstract override void Enter();

        public abstract override void Update();

        public abstract override void Exit();

        public abstract override string GetDescription();

        public new static TState ConstructState<TState, TCharacter>(TCharacter character, object[] arguments)
            where TState : StaffState where TCharacter : Staff =>
            CharacterStateFactory.ConstructState<TState>(character, arguments);

        public new static TState ConstructState<TState, TCharacter>(TCharacter character)
            where TState : StaffState where TCharacter : Staff => 
            ConstructState<TState, TCharacter>(character, null);
    }
}