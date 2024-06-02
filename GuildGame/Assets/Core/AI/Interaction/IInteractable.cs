using UnityEngine;

namespace com.Halkyon.AI.Interaction
{
    public interface IInteractable
    {
        Vector3 Position { get; }
        
        void Interact(Character.Character character);
        void Register(IInteractable interactable);
    }
}