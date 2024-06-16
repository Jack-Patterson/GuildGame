using com.Halkyon.AI.Character.Actions;
using UnityEngine;

namespace com.Halkyon.AI.Character
{
    [RequireComponent(typeof(StaffActionHandler))]
    public class Staff : Character
    {
        public new readonly string CharacterType = "Staff";
        public new StaffActionHandler ActionHandler => (StaffActionHandler) base.ActionHandler;

        private new void Awake()
        {
            base.Awake();
        }
        
        private new void Start()
        {
            base.Start();
            CharacterManager.RequestAttributes(this);
        }
    }
}