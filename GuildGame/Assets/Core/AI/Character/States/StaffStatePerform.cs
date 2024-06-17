using com.Halkyon.AI.Character.StaffJobs;

namespace com.Halkyon.AI.Character.States
{
    public class StaffStatePerform : StaffState
    {
        public StaffStatePerform(Staff character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            Character.ActionHandler.IsPerformingTask = true;

            if (Arguments[0] is string)
            {
                // Trigger animation
            }
        }

        public override void Update()
        {
            Character.ActionHandler.IsPerformingTask = false;
            Character.ActionHandler.MoveToNextState();
        }

        public override void Exit()
        {
        }

        public override string GetDescription()
        {
            return "Working...";
        }
    }
}