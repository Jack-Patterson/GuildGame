using UnityEngine;

namespace com.Halcyon.Core.Character.Jobs
{
    public class Bartender : Character
    {
        [SerializeField] private Transform interactDrinkStandPos;
        [SerializeField] private Transform interactDrinkLookPos;
        [SerializeField] private Transform placeDrinkStandPos;
        [SerializeField] private Transform placeDrinkLookPos;

        private void Start()
        {
            TaskHandler.AddSequence(new TaskSequence(new Task[]
            {
                new MoveTask(this, interactDrinkStandPos.position),
                new LookAtTask(this, interactDrinkLookPos.position),
                new WaitTask(this, 1.5f),
                new PrintTask(this, "Interacting with drink stand"),
                new MoveTask(this, placeDrinkStandPos.position),
                new LookAtTask(this, placeDrinkLookPos.position),
                new WaitTask(this, 1.5f),
                new PrintTask(this, "Placing drink")
            }, true));
        }
    }
}