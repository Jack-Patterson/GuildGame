using System;
using com.Halcyon.Core.AI.OldCharacter.Character.Tasks;

namespace com.Halcyon.Core.AI.InteractableObjects
{
    public class Table : InteractableObject
    {
        public override TaskSequence GetTaskSequence(OldCharacter.Character.Character character)
        {
            TaskPool taskPool = new TaskPool();
            TaskSequence sequence = new TaskSequence(taskPool);

            taskPool.RegisterTaskFactory(characterInCtor => new MoveTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new VelocityTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new SetParentTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new WaitTask(characterInCtor));

            // sequence.AddTask<MoveTask>(character, task => task.SetDestination(interactDrinkStandPos.position));
            // sequence.AddTask<VelocityTask>(character, task => task.SetVelocity(Vector3.zero));
            // sequence.AddTask<LookAtTask>(character, task => task.SetLookPosition(interactDrinkLookPos.position));
            // sequence.AddTask<WaitTask>(character, task => task.SetWaitTime(1.5f));
            // sequence.AddTask<InteractTask>(character, task => task.SetInteractableObject(this));
            // sequence.AddTask<MoveTask>(character, task => task.SetDestination(placeDrinkStandPos.position));
            // sequence.AddTask<VelocityTask>(character, task => task.SetVelocity(Vector3.zero));
            // sequence.AddTask<LookAtTask>(character, task => task.SetLookPosition(placeDrinkLookPos.position));
            // sequence.AddTask<WaitTask>(character, task => task.SetWaitTime(1.5f));
            // sequence.AddTask<InteractSecondaryTask>(character, task => task.SetInteractableObject(this));

            return sequence;
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}