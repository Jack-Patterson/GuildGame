using com.Halcyon.Core.AI.OldCharacter.Character.Tasks;
using UnityEngine;

namespace com.Halcyon.Core.AI.InteractableObjects
{
    public class Bar : InteractableObject
    {
        [SerializeField] private Transform interactDrinkStandPos;
        [SerializeField] private Transform interactDrinkLookPos;
        [SerializeField] private Transform placeDrinkStandPos;
        [SerializeField] private Transform placeDrinkLookPos;
        
        public override TaskSequence GetTaskSequence(OldCharacter.Character.Character character)
        {
            TaskPool taskPool = new TaskPool();
            TaskSequence sequence = new TaskSequence(taskPool, true);
            
            taskPool.RegisterTaskFactory(characterInCtor => new MoveTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new VelocityTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new LookAtTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new WaitTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new InteractTask(characterInCtor));
            taskPool.RegisterTaskFactory(characterInCtor => new InteractSecondaryTask(characterInCtor));
            
            sequence.AddTask<MoveTask>(character, task => task.SetDestination(interactDrinkStandPos.position));
            sequence.AddTask<VelocityTask>(character, task => task.SetVelocity(Vector3.zero));
            sequence.AddTask<LookAtTask>(character, task => task.SetLookPosition(interactDrinkLookPos.position));
            sequence.AddTask<WaitTask>(character, task => task.SetWaitTime(1.5f));
            sequence.AddTask<InteractTask>(character, task => task.SetInteractableObject(this));
            sequence.AddTask<MoveTask>(character, task => task.SetDestination(placeDrinkStandPos.position));
            sequence.AddTask<VelocityTask>(character, task => task.SetVelocity(Vector3.zero));
            sequence.AddTask<LookAtTask>(character, task => task.SetLookPosition(placeDrinkLookPos.position));
            sequence.AddTask<WaitTask>(character, task => task.SetWaitTime(1.5f));
            sequence.AddTask<InteractSecondaryTask>(character, task => task.SetInteractableObject(this));
            
            return sequence;
        }

        public override void Interact()
        {
            print("Interacting with drink stand");
        }

        public override void InteractSecondary()
        {
            print("Placing drink");
        }
    }
}