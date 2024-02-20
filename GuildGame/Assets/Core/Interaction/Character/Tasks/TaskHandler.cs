using System.Collections.Generic;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.Interaction.Character.Tasks
{
    public class TaskHandler : ExtendedMonoBehaviour
    {
        private readonly Queue<TaskSequence> _sequences = new();
        private TaskSequence _currentSequence;
        private Task _currentTask;

        void Update()
        {
            if (_currentTask == null)
            {
                if (_currentSequence == null || _currentSequence.GetCurrentTask() == null)
                {
                    if (_sequences.Count > 0 && _currentSequence == null)
                    {
                        _currentSequence = _sequences.Dequeue();
                        _currentSequence.Reset();
                    }
                    else if (_currentSequence != null && !_currentSequence.IsLooping)
                    {
                        _currentSequence = _sequences.Count > 0 ? _sequences.Dequeue() : null;
                        if (_currentSequence != null) _currentSequence.Reset();
                    }
                }

                StartNextTaskInSequence();
            }
        }

        private void StartNextTaskInSequence()
        {
            if (_currentSequence != null)
            {
                _currentTask = _currentSequence.GetCurrentTask();
                if (_currentTask != null)
                {
                    _currentTask.OnTaskCompleted += OnCurrentTaskCompleted;
                    _currentTask.Execute();
                }
                else if (_currentSequence.IsLooping)
                {
                    _currentSequence.Reset();
                    StartNextTaskInSequence();
                }
            }
        }

        private void OnCurrentTaskCompleted()
        {
            _currentTask.OnTaskCompleted -= OnCurrentTaskCompleted;
            _currentTask = null;
            _currentSequence?.MoveToNextTask();
        }

        public void AddSequence(TaskSequence sequence)
        {
            _sequences.Enqueue(sequence);
        }

        public void SetSequence(TaskSequence sequence)
        {
            ClearSequences();
            
            AddSequence(sequence);
        }

        public void EndCurrentSequence()
        {
            if (_currentTask != null)
            {
                _currentTask.Stop();
                _currentTask = null;
            }

            _currentSequence = null;
        }

        public void ClearSequences()
        {
            EndCurrentSequence();
            
            _sequences.Clear();
        }
    }
}