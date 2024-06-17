namespace com.Halkyon.AI.Character.Actions
{
    public class StaffActionHandler : CharacterActionHandler
    {
        internal bool IsPerformingTask { get; set; }
        protected override void FindInitialTask(){}


        protected override void DetermineNextState(bool questNotFound = false)
        {
        }
    }
}