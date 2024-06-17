using System.Collections;
using com.Halkyon.AI.Character.StaffJobs;
using com.Halkyon.Utils;
using UnityEngine;

namespace com.Halkyon.AI.Character.States
{
    public class StaffStatePerform : StaffState
    {
        public StaffStatePerform(Staff character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            Character.ActionHandler.IsPerformingTask = true;

            if (Arguments != null && Arguments.Length > 0 && Arguments[0] is string)
            {
                // Trigger animation
            }
            
            CoroutineRunner.RunCoroutine(Character.PerformJob());
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }

        public override string GetDescription()
        {
            return "Working...";
        }
    }
}