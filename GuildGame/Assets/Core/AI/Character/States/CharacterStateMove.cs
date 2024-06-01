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
            else if (Arguments[0] is Transform)
            {
                _target = ((Transform)Arguments[0]).position;
                print($"Moving to target {_target}");
                Character.Agent.SetDestination(_target);
            }
            else
            {
                throw new ArgumentException("Invalid argument type. Expected Vector3 or Transform.");
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

        public override void Reset()
        {
            _target = default;
        }

        public override string GetDescription()
        {
            float distance = Vector3.Distance(Character.Position, _target);
            string message = $"Moving to target position. Distance: {distance:F1}";
            
            return message;
        }
    }
}