using System;
using System.Collections;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.AI.OldCharacter.Character.Tasks
{
    public abstract class Task : LoggerUtil
    {
        public event Action OnTaskCompleted = null!;
        protected Character Character;
        protected IEnumerator CurrentCoroutine = null!;

        protected Task(Character character)
        {
            Character = character;
        }

        public abstract void Execute();

        public virtual void Reset(){}

        public void Stop()
        {
            if (CurrentCoroutine != null)
            {
                CoroutineRunner.Instance.StopRunningCoroutine(CurrentCoroutine);
                CurrentCoroutine = null;
            }
        }

        protected void StartTaskCoroutine(IEnumerator coroutine)
        {
            CurrentCoroutine = coroutine;
            CoroutineRunner.Instance.RunCoroutine(coroutine);
        }

        protected void CompleteTask()
        {
            OnTaskCompleted?.Invoke();
            CurrentCoroutine = null;
        }
    }
}