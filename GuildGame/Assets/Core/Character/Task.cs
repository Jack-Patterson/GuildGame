using System;
using System.Collections;
using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Character
{
    public abstract class Task : API.Core.Character.CharacterTasks.Task
    {
        protected Character Character;
        public event Action OnTaskCompleted = null!;
        protected IEnumerator CurrentCoroutine = null!;

        protected Task(Character character)
        {
            Character = character;
        }

        public abstract void Execute();
        
        public virtual void Reset(){}

        protected void StartTaskCoroutine(IEnumerator coroutine)
        {
            CurrentCoroutine = coroutine;
            CoroutineRunner.Instance.RunCoroutine(coroutine);
        }

        public virtual void Stop()
        {
            if (CurrentCoroutine != null)
            {
                CoroutineRunner.Instance.StopRunningCoroutine(CurrentCoroutine);
                CurrentCoroutine = null;
            }
        }

        protected void CompleteTask()
        {
            OnTaskCompleted?.Invoke();
            CurrentCoroutine = null;
        }
    }
    
    public class MoveTask : Task
    {
        private Vector3 _destination;

        public MoveTask(Character character, Vector3 destination) : base(character)
        {
            _destination = destination;
        }

        public override void Execute()
        {
            StartTaskCoroutine(MoveToPosition());
        }

        public override void Reset()
        {
            _destination = default;
        }
        
        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }

        private IEnumerator MoveToPosition()
        {
            Character.SetTarget(_destination);
            yield return null;
        
            while (!Character.DestinationReached())
            {
                yield return null;
            }
            Character.Stop();
            CompleteTask();
        }
    }

    public class PrintTask : Task
    {
        private string _message;
        public PrintTask(Character character, string message) : base(character)
        {
            _message = message;
        }

        public override void Execute()
        {
            Print(_message);
            CompleteTask();
        }
    }

    public class LookAtTask : Task
    {
        private Vector3 _lookAtTarget;
        
        public LookAtTask(Character character, Vector3 lookAtTarget) : base(character)
        {
            _lookAtTarget = lookAtTarget;
        }

        public override void Execute()
        {
            StartTaskCoroutine(LookAt());
        }
        
        private IEnumerator LookAt()
        {
            Vector3 direction = (_lookAtTarget - Character.transform.position).normalized;
            Character.transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            
            CompleteTask();

            yield return null;
        }
    }
    
    public class WaitTask : Task
    {
        private float _timeToWait;
        
        public WaitTask(Character character, float timeToWait) : base(character)
        {
            _timeToWait = timeToWait;
        }

        public override void Execute()
        {
            StartTaskCoroutine(Wait());
        }
        
        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(_timeToWait);
            CompleteTask();
        }
    }
}