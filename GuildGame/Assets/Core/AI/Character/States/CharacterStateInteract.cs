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
            if (Arguments == null || Arguments.Length == 0)
            {
                throw new ArgumentException("Invalid argument count. Expected at least 1 argument.");
            }
            
            if (Arguments[0] is IInteractable)
            {
                IInteractable interactable = (IInteractable)Arguments[0];
                HandleInteraction(interactable, ShouldHandleInteraction());
            }
            else if (Arguments[0] is Transform)
            {
                IInteractable interactable = ((Transform)Arguments[0]).GetComponent<IInteractable>();
                HandleInteraction(interactable, ShouldHandleInteraction());
            }
            else if (Arguments[0] is GameObject)
            {
                IInteractable interactable = ((GameObject)Arguments[0]).GetComponent<IInteractable>();
                HandleInteraction(interactable, ShouldHandleInteraction());
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
            return "Interacting...";
        }

        private void HandleInteraction(IInteractable interactable, bool isInteractableHandlingState = false)
        {
            print($"Interacting with {interactable}");
            interactable.Interact(Character);
            
            if (!isInteractableHandlingState)
            {
                Character.ActionHandler.MoveToNextState();
                print("Done interacting. Moving to next state.");
            }
        }

        private bool ShouldHandleInteraction()
        {
            if (Arguments.Length < 2)
                return false;
            
            if (Arguments[1] is bool boolean)
                return boolean;
            
            return false;
        }
    }
}