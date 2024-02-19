using System;
using System.Collections.Generic;
using com.Halcyon.Core.Character.Tasks;

namespace com.Halcyon.Core.Character
{
    public class TaskPool
    {
        private Dictionary<Type, Queue<Task>> pools = new();
        private Dictionary<Type, Func<Character, Task>> factories = new();
        
        public void RegisterTaskFactory<T>(Func<Character, T> factory) where T : Task
        {
            factories[typeof(T)] = character => factory(character);
        }

        public T GetTask<T>(Character character) where T : Task
        {
            Queue<Task> queue;
            if (!pools.TryGetValue(typeof(T), out queue))
            {
                queue = new Queue<Task>();
                pools[typeof(T)] = queue;
            }

            if (queue.Count > 0)
            {
                var task = (T)queue.Dequeue();
                task.Reset();
                return task;
            }
            else if (factories.TryGetValue(typeof(T), out var factory))
            {
                return (T)factory(character);
            }
            else
            {
                throw new InvalidOperationException($"No factory method registered for {typeof(T)}");
            }
        }

        public void ReturnTask(Task task)
        {
            Type taskType = task.GetType();
            if (!pools.ContainsKey(taskType))
            {
                pools[taskType] = new Queue<Task>();
            }
            task.Reset();
            pools[taskType].Enqueue(task);
        }
    }
}