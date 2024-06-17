using UnityEngine;

namespace com.Halkyon.AI.Interaction
{
    public abstract class InteractableMonoBehaviour : ExtendedMonoBehaviour, IInteractable
    {
        public new Vector3 Position => base.Position;
        public abstract void Interact(Character.Character character);

        protected void Awake()
        {
            Register();
        }

        public void Register()
        {
            InteractableManager.Instance.Register(this);
        }

        private void OnDisable()
        {
            InteractableManager.Instance.Register(this);
        }

        private void OnDestroy()
        {
            InteractableManager.Instance.Unregister(this);
        }
    }
}