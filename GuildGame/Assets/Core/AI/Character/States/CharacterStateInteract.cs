using System;
using com.Halkyon.AI.Interaction;
using UnityEngine;

namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateInteract : CharacterState
    {
        public CharacterStateInteract(Character character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            if (Arguments[0] is IInteractable)
            {
                IInteractable interactable = (IInteractable)Arguments[0];
                HandleInteraction(interactable);
                Character.ActionHandler.MoveToNextState();
            }
            else if (Arguments[0] is Transform)
            {
                Transform transform = (Transform)Arguments[0];
                IInteractable interactable = transform.GetComponent<IInteractable>();
                HandleInteraction(interactable);
                Character.ActionHandler.MoveToNextState();
            }
            else if (Arguments[0] is GameObject)
            {
                GameObject gameObject = (GameObject)Arguments[0];
                IInteractable interactable = gameObject.GetComponent<IInteractable>();
                HandleInteraction(interactable);
                Character.ActionHandler.MoveToNextState();
            }
            else
            {
                throw new ArgumentException("Invalid argument type. Expected IInteractable, Transform, or GameObject.");
            }
        }

        public override void Update()
        {
        }


        public override void Exit()
        {
        }

        public override string GetDescription()
        {
            return "";
        }
        
        private void HandleInteraction(IInteractable interactable)
        {
            print($"Interacting with {interactable}");
            interactable.Interact(Character);
        }
    }
}