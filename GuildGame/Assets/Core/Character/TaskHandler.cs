using System.Collections.Generic;
using com.Halcyon.API.Core.Character.CharacterTasks;
using UnityEngine;

namespace com.Halcyon.Core.Character
{
    public class TaskHandler : API.Core.Character.CharacterTasks.TaskHandler
    {
        private void Start()
        {
            Tasks.Add(new MoveTask(Character));
            Tasks[0].Perform();
            ((Task<Vector3>)Tasks[0]).Perform(new Vector3(10, 0, 10));
        }

        public override void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public override void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }

        public override void SetTasks(List<Task> tasks)
        {
            this.tasks = tasks;
        }
    }
}