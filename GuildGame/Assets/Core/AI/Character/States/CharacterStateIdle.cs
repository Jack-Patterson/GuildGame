namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateIdle : CharacterState
    {
        public CharacterStateIdle(Character character) : base(character)
        {
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            InvokeOnStateExit();
        }
    }
}