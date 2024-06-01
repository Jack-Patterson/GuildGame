using System.Collections.Generic;
using com.Halkyon.AI.Character.States;

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

        public void QueueState(CharacterState characterState, object[] arguments = null)
        {
            if (_currentState is CharacterStateIdle)
                ChangeState(characterState, arguments);
            else
                _stateQueue.Enqueue((characterState, arguments));
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
    }
}