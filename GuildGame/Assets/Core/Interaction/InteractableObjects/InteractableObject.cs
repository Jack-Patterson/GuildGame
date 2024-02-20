using com.Halcyon.API.Core;
using com.Halcyon.Core.Interaction.Character.Tasks;

namespace com.Halcyon.Core.Interaction.InteractableObjects
{
    public abstract class InteractableObject : ExtendedMonoBehaviour, IInteractableObject
    {
        private void Start()
        {
            InteractableObjectHandler.Instance.Register(this);
        }
        
        public abstract TaskSequence GetTaskSequence(Character.Character character);

        public abstract void Interact();
        
        public virtual void InteractSecondary()
        {
        }
    }
}