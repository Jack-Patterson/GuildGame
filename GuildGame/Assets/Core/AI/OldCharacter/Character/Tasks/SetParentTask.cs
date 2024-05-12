using UnityEngine;

namespace com.Halcyon.Core.AI.OldCharacter.Character.Tasks
{
    public class SetParentTask : Task
    {
        private Transform _parent;
        
        public SetParentTask(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            Character.transform.parent = _parent;
        }
        
        public void SetParent(Transform parentTransform)
        {
            _parent = parentTransform;
        }
    }
}