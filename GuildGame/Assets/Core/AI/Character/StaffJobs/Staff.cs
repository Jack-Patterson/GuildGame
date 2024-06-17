using System.Collections;
using com.Halkyon.AI.Character.Actions;
using com.Halkyon.AI.Interaction.Stations;
using UnityEngine;

namespace com.Halkyon.AI.Character.StaffJobs
{
    [RequireComponent(typeof(StaffActionHandler))]
    public abstract class Staff : Character
    {
        public new StaffActionHandler ActionHandler => (StaffActionHandler) base.ActionHandler;
        public StaffWorkstation Workstation { get; set; }
        public bool IsPerformingTask => ActionHandler.IsPerformingTask;

        protected new void Awake()
        {
            base.Awake();
        }
        
        protected new void Start()
        {
            base.Start();
            CharacterManager.RequestAttributes(this);
        }

        public abstract IEnumerator PerformJob();
    }
}