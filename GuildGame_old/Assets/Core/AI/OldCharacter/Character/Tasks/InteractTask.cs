﻿using com.Halcyon.Core.AI.InteractableObjects;
using com.Halcyon.Core.Interaction.InteractableObjects;

namespace com.Halcyon.Core.AI.OldCharacter.Character.Tasks
{
    public class InteractTask : Task
    {
        protected IInteractableObject InteractableObject;
        
        public InteractTask(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            InteractableObject.Interact();
            CompleteTask();
        }

        public override void Reset()
        {
            InteractableObject = null;
        }

        public void SetInteractableObject(IInteractableObject interactableObject)
        {
            InteractableObject = interactableObject;
        }
    }
}