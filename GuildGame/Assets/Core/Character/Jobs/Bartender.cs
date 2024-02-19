﻿using com.Halcyon.Core.Character.Tasks;
using UnityEngine;

namespace com.Halcyon.Core.Character.Jobs
{
    public class Bartender : Character
    {
        [SerializeField] private Transform interactDrinkStandPos;
        [SerializeField] private Transform interactDrinkLookPos;
        [SerializeField] private Transform placeDrinkStandPos;
        [SerializeField] private Transform placeDrinkLookPos;

        private void Start()
        {
            TaskPool taskPool = new TaskPool();
            TaskSequence sequence = new TaskSequence(taskPool, true);
            
            taskPool.RegisterTaskFactory(character => new MoveTask(character));
            taskPool.RegisterTaskFactory(character => new PrintTask(character));
            taskPool.RegisterTaskFactory(character => new LookAtTask(character));
            taskPool.RegisterTaskFactory(character => new WaitTask(character));
            
            sequence.AddTask<MoveTask>(this, task => task.SetDestination(interactDrinkStandPos.position));
            sequence.AddTask<LookAtTask>(this, task => task.SetLookPosition(interactDrinkLookPos.position));
            sequence.AddTask<WaitTask>(this, task => task.SetWaitTime(1.5f));
            sequence.AddTask<PrintTask>(this, task => task.SetPrintMessage("Interacting with drink stand"));
            sequence.AddTask<MoveTask>(this, task => task.SetDestination(placeDrinkStandPos.position));
            sequence.AddTask<LookAtTask>(this, task => task.SetLookPosition(placeDrinkLookPos.position));
            sequence.AddTask<WaitTask>(this, task => task.SetWaitTime(1.5f));
            sequence.AddTask<PrintTask>(this, task => task.SetPrintMessage("Placing drink"));
            
            TaskHandler.AddSequence(sequence);
        }
    }
}