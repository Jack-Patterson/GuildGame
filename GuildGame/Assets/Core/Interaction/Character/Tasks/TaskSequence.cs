using System;
using System.Collections.Generic;

namespace com.Halcyon.Core.Interaction.Character.Tasks
{
    public class TaskSequence : API.Core.Character.CharacterTasks.TaskSequence
    {
        private List<Task> _tasks = new();
        private int _currentIndex;
        private TaskPool _taskPool;
        public bool IsLooping { get; set; }

        public TaskSequence(TaskPool pool, bool isLooping = false)
        {
            _taskPool = pool;
            IsLooping = isLooping;
        }
        
        public void AddTask<T>(Interaction.Character.Character character, Action<T> configureTask) where T : Task
        {
            var task = _taskPool.GetTask<T>(character);
            configureTask(task);
            _tasks.Add(task);
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