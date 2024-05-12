namespace com.Halcyon.Core.AI.OldCharacter.Character.Tasks
{
    public class InteractSecondaryTask : InteractTask
    {
        public InteractSecondaryTask(Character character) : base(character)
        {
        }
        
        public override void Execute()
        {
            InteractableObject.InteractSecondary();
            CompleteTask();
        }
    }
}