using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction;
using com.Halkyon.AI.Interaction.Stations;

namespace com.Halkyon.AI.Character
{
    public class CharacterActionHandler : ExtendedMonoBehaviour
    {
        private Character _character;
        private ICharacterState _currentState;
        private Queue<(ICharacterState state, object[] args)> _stateQueue = new Queue<(ICharacterState, object[])>();

        private void Awake()
        {
            _character = GetComponent<Character>();
            ChangeState(CharacterState.ConstructState<CharacterStateIdle>(_character));
        }

        private void Start()
        {
            FindInitialTask();
        }

        private void Update()
        {
            _currentState?.Update();
        }

        public void ChangeState(ICharacterState characterState, object[] arguments = null,
            bool forceStateChange = false)
        {
            if (forceStateChange)
                _stateQueue.Clear();

            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = characterState;

            if (arguments != null)
            {
                _currentState.Reset();
                _currentState.UpdateArgs(arguments);
            }

            _currentState.Enter();
        }

        public void QueueState(CharacterState characterState, object[] arguments = null, bool overwriteQueue = false)
        {
            if (overwriteQueue)
                _stateQueue.Clear();
            
            if (_currentState is CharacterStateIdle)
                ChangeState(characterState, arguments);
            else
                _stateQueue.Enqueue((characterState, arguments));
        }
        
        public void QueueStates(List<(CharacterState state, object[] args)> states, bool overwriteQueue = false)
        {
            if (overwriteQueue)
                _stateQueue.Clear();
            
            if (_currentState is CharacterStateIdle)
            {
                ChangeState(states[0].state, states[0].args);
                states.RemoveAt(0);
            }
            
            foreach ((CharacterState state, object[] args) in states)
            {
                _stateQueue.Enqueue((state, args));
            }
        }

        internal void MoveToNextState()
        {
            if (_stateQueue.Count > 0)
            {
                ICharacterState nextState;
                object[] arguments;
                (nextState, arguments) = _stateQueue.Dequeue();
                ChangeState(nextState, arguments);
            }
            else
            {
                ChangeState(CharacterState.ConstructState<CharacterStateIdle>(_character));
            }
        }
        
        private void FindInitialTask()
        {
            if (_character.Rank == CharacterRank.None)
            {
                GuildDesk guildDesk = InteractableManager.Instance.GetClosestInteractableOfType<GuildDesk>(Position);
                CharacterStateMove moveState =
                    CharacterState.ConstructState<CharacterStateMove>(_character, new object[] { guildDesk.Position });
                CharacterStateInteract interactState =
                    CharacterState.ConstructState<CharacterStateInteract>(_character, new object[] { guildDesk });

                QueueStates(new List<(CharacterState state, object[] args)> { (moveState, null), (interactState, null) });
            }
        }
    }
}