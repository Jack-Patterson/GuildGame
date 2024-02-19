using System.Collections;
using UnityEngine;

namespace com.Halcyon.API.Core.Character.CharacterTasks;

public abstract class Task : LoggerUtil
{
    // protected Character Character;
    // public event Action OnTaskCompleted = null!;
    // protected IEnumerator CurrentCoroutine = null!;
    //
    // protected Task(Character character)
    // {
    //     Character = character;
    // }
    //
    // public abstract void Execute();
    //
    // protected void StartTaskCoroutine(IEnumerator coroutine)
    // {
    //     CurrentCoroutine = coroutine;
    //     CoroutineRunner.Instance.RunCoroutine(coroutine);
    // }
    //
    // public virtual void Stop()
    // {
    //     if (CurrentCoroutine != null)
    //     {
    //         CoroutineRunner.Instance.StopRunningCoroutine(CurrentCoroutine);
    //         CurrentCoroutine = null;
    //     }
    // }
    //
    // protected void CompleteTask()
    // {
    //     OnTaskCompleted?.Invoke();
    //     CurrentCoroutine = null;
    // }
}

// public class MoveTask : Task
// {
//     private Vector3 _destination;
//
//     public MoveTask(Vector3 destination, Character character) : base(character)
//     {
//         _destination = destination;
//     }
//
//     public override void Execute()
//     {
//         StartTaskCoroutine(MoveToPosition());
//     }
//     
//     private IEnumerator MoveToPosition()
//     {
//         Character.SetTarget(_destination);
//         yield return null;
//         
//         while (!Character.DestinationReached())
//         {
//             yield return null;
//         }
//         CompleteTask();
//     }
// }
//
// public class PrintTask : Task
// {
//     private string _message;
//     public PrintTask(Character character, string message) : base(character)
//     {
//         _message = message;
//     }
//
//     public override void Execute()
//     {
//         Print(_message);
//         CompleteTask();
//     }
// }