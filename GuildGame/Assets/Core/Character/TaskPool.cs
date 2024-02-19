using System;
using System.Collections.Generic;

namespace com.Halcyon.Core.Character
{
    public class TaskPool
    {
        private Dictionary<Type, Queue<Task>> pools = new();

        public T GetTask<T>(Character character) where T : Task
        {
            if (!pools.TryGetValue(typeof(T), out var queue))
            {
                queue = new Queue<Task>();
                pools[typeof(T)] = queue;
            }

            if (queue.Count == 0)
            {
                return Activator.CreateInstance(typeof(T), character) as T;
            }
            else
            {
                var task = queue.Dequeue() as T;
                task!.Reset();
                return task;
            }
        }

        public void ReturnTask(Task task)
        {
            task.Reset(); // Reset task state before pooling
            Type taskType = task.GetType();
            if (!pools.ContainsKey(taskType))
            {
                pools[taskType] = new Queue<Task>();
            }
            pools[taskType].Enqueue(task);
        }
    }
}