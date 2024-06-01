namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateIdle : CharacterState
    {
        public CharacterStateIdle(Character character, object[] args) : base(character, args)
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
        }

        public override string GetDescription()
        {
            string message = "Idling";
            return message;
        }
    }
}