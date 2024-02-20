using UnityEngine;

namespace com.Halcyon.Core.Character.Tasks
{
    public class VelocityTask : Task
    {
        private Vector3 _velocity;
        
        public VelocityTask(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            Character.Velocity = _velocity;
            CompleteTask();
        }
        
        public override void Reset()
        {
            _velocity = default;
        }
        
        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
        }
    }
}