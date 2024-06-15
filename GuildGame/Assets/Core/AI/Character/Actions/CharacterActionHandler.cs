using System.Collections.Generic;
using System.Linq;
using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction;
using com.Halkyon.AI.Interaction.Quests;

namespace com.Halkyon.AI.Character.Actions
{
    public abstract class CharacterActionHandler : ExtendedMonoBehaviour
    {
        protected Character Character;
        protected internal ICharacterState CurrentState;
        protected readonly Queue<(ICharacterState state, object[] args)> StateQueue = new();

        protected void Awake()
        {
            Character = GetComponent<Character>();
            ChangeState(CharacterState.ConstructState<CharacterStateIdle>(Character));
        }

        protected void Start()
        {
            FindInitialTask();
        }

        protected void Update()
        {
            CurrentState?.Update();

            if (CurrentState is CharacterStateIdle)
            {
                // DetermineNextState();
            }
        }

        public void ChangeState(ICharacterState characterState, object[] arguments = null,
            bool forceStateChange = false)
        {
            if (forceStateChange)
                StateQueue.Clear();

            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            CurrentState = characterState;

            if (arguments != null)
            {
                CurrentState.Reset();
                CurrentState.UpdateArgs(arguments);
            }

            CurrentState.Enter();
        }

        public void QueueState(CharacterState characterState, object[] arguments = null, bool overwriteQueue = false)
        {
            if (overwriteQueue)
                StateQueue.Clear();

            if (CurrentState is CharacterStateIdle)
                ChangeState(characterState, arguments);
            else
                StateQueue.Enqueue((characterState, arguments));
        }

        public void QueueStates(List<(CharacterState state, object[] args)> states, bool overwriteQueue = false)
        {
            if (overwriteQueue)
                StateQueue.Clear();

            if (CurrentState is CharacterStateIdle)
            {
                ChangeState(states[0].state, states[0].args);
                states.RemoveAt(0);
            }

            foreach ((CharacterState state, object[] args) in states)
            {
                StateQueue.Enqueue((state, args));
            }
        }

        public void QueueStates(List<CharacterState> states, bool overwriteQueue = false)
        {
            List<(CharacterState, object[])> statesTransformed = states.Select(state => (state, (object[])null)).ToList();
            QueueStates(statesTransformed, overwriteQueue);
        }

        public void AssignQuest(Quest quest)
        {
            if (quest != null)
            {
                print(quest);
            }
        }

        internal void MoveToNextState()
        {
            if (StateQueue.Count > 0)
            {
                ICharacterState nextState;
                object[] arguments;
                (nextState, arguments) = StateQueue.Dequeue();
                ChangeState(nextState, arguments);
            }
            else
            {
                ChangeState(CharacterState.ConstructState<CharacterStateIdle>(Character));
            }
        }

        protected List<CharacterState> FindAndInteractWithInteractable<T>() where T : IInteractable
        {
            T closestInteractableOfType = InteractableManager.Instance.GetClosestInteractableOfType<T>(Position);
            CharacterStateMove moveState =
                CharacterState.ConstructState<CharacterStateMove>(Character,
                    new object[] { closestInteractableOfType.Position });
            CharacterStateInteract interactState =
                CharacterState.ConstructState<CharacterStateInteract>(Character,
                    new object[] { closestInteractableOfType });
            
            List<CharacterState> states = new List<CharacterState> { moveState, interactState };

            return states;
        }

        protected bool CanTakeQuest()
        {
            return true;
        }

        protected abstract void FindInitialTask();

        protected abstract void DetermineNextState(bool questNotFound = false);
    }
}