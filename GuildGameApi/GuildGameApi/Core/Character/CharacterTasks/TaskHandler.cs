namespace com.Halcyon.API.Core.Character.CharacterTasks;

public abstract class TaskHandler : ExtendedMonoBehaviour
{
    // private TaskSequence _currentSequence;
    // private Task _currentTask;
    //
    // void Update()
    // {
    //     if (_currentTask == null)
    //     {
    //         if (_currentSequence != null)
    //         {
    //             StartNextTaskInSequence();
    //         }
    //     }
    // }
    //
    // private void StartNextTaskInSequence()
    // {
    //     _currentTask = _currentSequence?.GetCurrentTask();
    //     if (_currentTask != null)
    //     {
    //         _currentTask.Execute();
    //         _currentTask.OnTaskCompleted += OnCurrentTaskCompleted;
    //     }
    // }
    //
    // private void OnCurrentTaskCompleted()
    // {
    //     _currentTask.OnTaskCompleted -= OnCurrentTaskCompleted;
    //     _currentTask = null;
    //     _currentSequence.MoveToNextTask();
    // }
    //
    // public void SetSequence(TaskSequence sequence)
    // {
    //     if (_currentTask != null)
    //     {
    //         _currentTask.Stop();
    //         _currentTask = null;
    //     }
    //     _currentSequence = sequence;
    //     _currentSequence.Reset();
    // }
    //
    // public void EndCurrentSequence()
    // {
    //     if (_currentTask != null)
    //     {
    //         _currentTask.Stop();
    //         _currentTask = null;
    //     }
    //     _currentSequence = null;
    // }
}