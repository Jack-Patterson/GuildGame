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
            }
            else if (Arguments[0] is Transform)
            {
                IInteractable interactable = ((Transform)Arguments[0]).GetComponent<IInteractable>();
                HandleInteraction(interactable);
            }
            else if (Arguments[0] is GameObject)
            {
                IInteractable interactable = ((GameObject)Arguments[0]).GetComponent<IInteractable>();
                HandleInteraction(interactable);
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

        private void HandleInteraction(IInteractable interactable, bool isInteractableHandlingState = false)
        {
            print($"Interacting with {interactable}");
            interactable.Interact(Character);
            print("Done interacting. Moving to next state.");
            
            if (!isInteractableHandlingState)
                Character.ActionHandler.MoveToNextState();
        }
    }
}