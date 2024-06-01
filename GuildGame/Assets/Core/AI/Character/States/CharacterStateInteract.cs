namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateInteract : CharacterState
    {
        public CharacterStateInteract(Character character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            print("Interacting");
        }

        public override void Update()
        {
            
        }


        public override void Exit()
        {
        }
    }
}