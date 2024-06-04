using UnityEngine;

namespace com.Halkyon.AI.Interaction
{
    public abstract class InteractableMonoBehaviour : ExtendedMonoBehaviour, IInteractable
    {
        public new Vector3 Position => base.Position;
        public abstract void Interact(Character.Character character);

        protected void Start()
        {
            Register();
        }

        public void Register()
        {
            InteractableManager.Instance.Register(this);
        }
    }
}