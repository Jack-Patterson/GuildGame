using com.Halcyon.Core.Character.CharacterParameters.Stats;
using com.Halcyon.Core.Character.Tasks;
using UnityEngine;

namespace com.Halcyon.Core.Character.Jobs.Staff
{
    public class Bartender : Staff<BartenderStats>
    {
        [SerializeField] private Transform interactDrinkStandPos;
        [SerializeField] private Transform interactDrinkLookPos;
        [SerializeField] private Transform placeDrinkStandPos;
        [SerializeField] private Transform placeDrinkLookPos;
        
        [SerializeField] private Transform leavePos;

        private new void Start()
        {
            base.Start();
            
            TaskPool taskPool = new TaskPool();
            TaskSequence sequence = new TaskSequence(taskPool, true);
            
            taskPool.RegisterTaskFactory(character => new MoveTask(character));
            taskPool.RegisterTaskFactory(character => new VelocityTask(character));
            taskPool.RegisterTaskFactory(character => new PrintTask(character));
            taskPool.RegisterTaskFactory(character => new LookAtTask(character));
            taskPool.RegisterTaskFactory(character => new WaitTask(character));
            
            sequence.AddTask<MoveTask>(this, task => task.SetDestination(interactDrinkStandPos.position));
            sequence.AddTask<VelocityTask>(this, task => task.SetVelocity(Vector3.zero));
            sequence.AddTask<LookAtTask>(this, task => task.SetLookPosition(interactDrinkLookPos.position));
            sequence.AddTask<WaitTask>(this, task => task.SetWaitTime(1.5f));
            sequence.AddTask<PrintTask>(this, task => task.SetPrintMessage("Interacting with drink stand"));
            sequence.AddTask<MoveTask>(this, task => task.SetDestination(placeDrinkStandPos.position));
            sequence.AddTask<VelocityTask>(this, task => task.SetVelocity(Vector3.zero));
            sequence.AddTask<LookAtTask>(this, task => task.SetLookPosition(placeDrinkLookPos.position));
            sequence.AddTask<WaitTask>(this, task => task.SetWaitTime(1.5f));
            sequence.AddTask<PrintTask>(this, task => task.SetPrintMessage("Placing drink"));
            
            TaskHandler.AddSequence(sequence);
        }

        public void Leave()
        {
            TaskPool taskPool = new TaskPool();
            TaskSequence sequence = new TaskSequence(taskPool);
            
            taskPool.RegisterTaskFactory(character => new MoveTask(character));
            taskPool.RegisterTaskFactory(character => new PrintTask(character));
            
            sequence.AddTask<MoveTask>(this, task => task.SetDestination(leavePos.position));
            sequence.AddTask<PrintTask>(this, task => task.SetPrintMessage("Left building."));
            
            TaskHandler.SetSequence(sequence);
        }
    }
}