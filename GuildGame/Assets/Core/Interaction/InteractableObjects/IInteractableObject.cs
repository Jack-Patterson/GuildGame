using com.Halcyon.Core.Interaction.Character.Tasks;

namespace com.Halcyon.Core.Interaction.InteractableObjects
{
    public interface IInteractableObject
    {
        public TaskSequence GetTaskSequence(Character.Character character);
        
        public void Interact();

        public void InteractSecondary();
    }
}