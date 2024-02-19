using System.Collections.Generic;

namespace com.Halcyon.Core.Character
{
    public class TaskSequence : API.Core.Character.CharacterTasks.TaskSequence
    {
        private List<Task> _tasks = new();
        private int _currentIndex;
        public bool IsLooping { get; set; }

        public TaskSequence(IEnumerable<Task> tasks, bool isLooping = false)
        {
            _tasks.AddRange(tasks);
            IsLooping = isLooping;
        }

        public Task GetCurrentTask()
        {
            return _currentIndex < _tasks.Count ? _tasks[_currentIndex] : null;
        }

        public void MoveToNextTask()
        {
            if (++_currentIndex >= _tasks.Count)
            {
                if (IsLooping)
                {
                    _currentIndex = 0;
                }
                else
                {
                    _currentIndex = _tasks.Count;
                }
            }
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}