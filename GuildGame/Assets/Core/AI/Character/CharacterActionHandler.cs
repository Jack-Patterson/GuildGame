using System.Collections.Generic;
using com.Halkyon.AI.Character.States;

namespace com.Halkyon.AI.Character
{
    public class CharacterActionHandler : ExtendedMonoBehaviour
    {
        private Character _character;
        private ICharacterState _currentState;
        private Queue<ICharacterState> _stateQueue = new Queue<ICharacterState>();

        private void Awake()
        {
            _character = GetComponent<Character>();
            ChangeState(CharacterState.ConstructState<CharacterStateIdle>(_character));
        }

        private void Update()
        {
            _currentState?.Update();
        }

        public void ChangeState(ICharacterState characterState, bool forceStateChange = false)
        {
            if (forceStateChange)
                _stateQueue.Clear();

            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = characterState;
            _currentState.Enter();
        }

        public void QueueState(CharacterState characterState)
        {
            _stateQueue.Enqueue(characterState);
        }

        internal void MoveToNextState()
        {
            if (_stateQueue.Count > 0)
            {
                ChangeState(_stateQueue.Dequeue());
            }
            else
            {
                ChangeState(CharacterState.ConstructState<CharacterStateIdle>(_character));
            }
        }
    }
}