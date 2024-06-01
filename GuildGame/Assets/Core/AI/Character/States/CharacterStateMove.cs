using System;
using UnityEngine;

namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateMove : CharacterState
    {
        private Vector3 _target;

        public CharacterStateMove(Character character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            if (Arguments[0] is Vector3)
            {
                _target = (Vector3)Arguments[0];
                print($"Moving to target {_target}");
                Character.Agent.SetDestination(_target);
            }
            else
            {
                throw new ArgumentException("Invalid argument type");
            }
        }

        public override void Update()
        {
            if (Character.Agent.remainingDistance <= Character.Agent.stoppingDistance)
            {
                Character.ActionHandler.MoveToNextState();
            }
        }

        public override void Exit()
        {
            print($"Arrived at target {_target}");
        }
    }
}