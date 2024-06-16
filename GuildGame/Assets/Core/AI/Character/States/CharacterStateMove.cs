using System;
using System.Collections;
using com.Halkyon.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.Halkyon.AI.Character.States
{
    public class CharacterStateMove : CharacterState
    {
        private Vector3 _target;
        private bool _isCheckingDistance = false;

        public CharacterStateMove(Character character, object[] args) : base(character, args)
        {
        }

        public override void Enter()
        {
            switch (Arguments[0])
            {
                case Vector3 vector:
                    SetTarget(vector);
                    break;
                case Transform transform:
                    SetTarget(transform.position);
                    break;
                default:
                    throw new ArgumentException("Invalid argument type. Expected Vector3 or Transform.");
            }
        }
        
        private IEnumerator CheckRemainingDistance()
        {
            yield return new WaitForSeconds(0.1f);
            
            _isCheckingDistance = true;
        }
        
        private void SetTarget(Vector3 target)
        {
            print($"Moving to target {target}");
            _target = target;
            Character.Agent.SetDestination(target);
            Object.FindObjectOfType<CoroutineRunner>().RunCoroutine(CheckRemainingDistance());
        }

        public override void Update()
        {
            if (_isCheckingDistance && Character.Agent.remainingDistance <= Character.Agent.stoppingDistance)
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