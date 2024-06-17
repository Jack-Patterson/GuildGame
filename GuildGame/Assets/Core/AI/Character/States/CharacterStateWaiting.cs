using System;
using System.Collections;
using com.Halkyon.AI.Character.StaffJobs;
using com.Halkyon.AI.Interaction.Stations;
using UnityEngine;

namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateWaiting : CharacterState
    {
        private StaffWorkstation _objectWaitingAt;
        private Staff _staff;

        public CharacterStateWaiting(Character character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            if (Arguments == null || Arguments.Length < 2)
            {
                throw new ArgumentException("Expected at least 2 arguments of type StaffWorkstation and Staff.");
            }

            if (Arguments[0] is StaffWorkstation workstation && Arguments[1] is Staff staff)
            {
                _objectWaitingAt = workstation;
                _staff = staff;
            }
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override string GetDescription()
        {
            return "Waiting...";
        }

        // private IEnumerator WaitUntilFree()
        // {
        //     // yield return new WaitUntil(() => _objectWaitingAt.GetFreeStaffMemberOfType<>())
        // }
    }
}