using com.Halcyon.API.Core;
using com.Halcyon.Core.AI.OldCharacter.Character.Tasks;
using com.Halcyon.Core.Interaction.InteractableObjects;

namespace com.Halcyon.Core.AI.InteractableObjects
{
    public abstract class InteractableObject : ExtendedMonoBehaviour, IInteractableObject
    {
        private void Start()
        {
            InteractableObjectHandler.Instance.Register(this);
        }
        
        public abstract TaskSequence GetTaskSequence(OldCharacter.Character.Character character);

        public abstract void Interact();
        
        public virtual void InteractSecondary()
        {
        }
    }
}