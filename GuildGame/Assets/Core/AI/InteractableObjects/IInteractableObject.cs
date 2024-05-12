using com.Halcyon.Core.AI.OldCharacter.Character.Tasks;
using com.Halcyon.Core.Interaction.Character.Tasks;

namespace com.Halcyon.Core.AI.InteractableObjects
{
    public interface IInteractableObject
    {
        public TaskSequence GetTaskSequence(OldCharacter.Character.Character character);
        
        public void Interact();

        public void InteractSecondary();
    }
}