namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateMove : CharacterState
    {
        public CharacterStateMove(Character character) : base(character)
        {
        }

        public override void Enter()
        {
            print("Moving to target");
        }
            
        public override void Update()
        {
            if (Character.Agent.remainingDistance <= Character.Agent.stoppingDistance)
            {
                Character.ActionHandler.ChangeState(ConstructState<CharacterStateIdle>(Character));
            }
        }
            
        public override void Exit()
        {
            print("Arrived at target");
            InvokeOnStateExit();
        }
    }
}