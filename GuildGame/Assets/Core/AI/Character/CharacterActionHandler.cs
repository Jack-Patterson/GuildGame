using System.Collections.Generic;
using com.Halkyon.AI.Character.States;

namespace com.Halkyon.AI.Character
{
    public class CharacterActionHandler : ExtendedMonoBehaviour
    {
        private Character _character;
        private CharacterState _currentState;
        private Queue<CharacterState> _stateQueue = new Queue<CharacterState>();
        private bool _shouldForceStateChange = false;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _character.OnUnsubscribeCharacterEvents += () => _currentState?.Exit();
            ChangeState(CharacterState.ConstructState<CharacterStateIdle>(_character));
        }

        private void Update()
        {
            _currentState?.Update();
        }

        public void ChangeState(CharacterState characterState, bool force = false)
        {
            _stateQueue.Clear();
            _shouldForceStateChange = force;
            
            if (_currentState != null)
            {
                _currentState.OnStateExit = null;
                _currentState.Exit();
            }
            
            _currentState = characterState;
            _currentState.OnStateExit += HandleStateExit;
            _currentState.Enter();
        }

        public void QueueState(CharacterState characterState)
        {
            _stateQueue.Enqueue(characterState);
        }

        private void HandleStateExit()
        {
            if (_shouldForceStateChange)
            {
                _shouldForceStateChange = false;
                return;
            }
            
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