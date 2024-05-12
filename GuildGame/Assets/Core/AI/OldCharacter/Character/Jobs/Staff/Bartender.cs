using com.Halcyon.Core.AI.InteractableObjects;
using com.Halcyon.Core.AI.OldCharacter.Character.Tasks;
using com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats;
using com.Halcyon.Core.Interaction.Character.Tasks;
using com.Halcyon.Core.Interaction.InteractableObjects;
using UnityEngine;

namespace com.Halcyon.Core.AI.OldCharacter.Character.Jobs.Staff
{
    public class Bartender : Staff<BartenderStats>
    {
        [SerializeField] private Transform leavePos;

        private new void Start()
        {
            base.Start();
            
            AssignBarAndBeginWorking();
        }

        public void AssignBarAndBeginWorking()
        {
            if (AssignedWorkstation == null)
            {
                AssignedWorkstation = InteractableObjectHandler.Instance.GetClosestInteractableObjectOfType<Bar>(transform.position);
            }
            
            TaskHandler.SetSequence(AssignedWorkstation.GetTaskSequence(this));
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