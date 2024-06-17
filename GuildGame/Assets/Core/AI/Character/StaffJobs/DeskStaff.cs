using System.Collections;
using com.Halkyon.AI.Interaction.Stations;
using UnityEngine;

namespace com.Halkyon.AI.Character.StaffJobs
{
    public class DeskStaff : Staff
    {
        public override string CharacterId => "npc_staff_desk";
        public override string CharacterType => "Desk Staff";

        private new void Awake()
        {
            base.Awake();
        }
        
        private new void Start()
        {
            base.Start();
            Workstation = FindObjectOfType<GuildDesk>();
            Workstation.AssignStaff(this);
        }

        public override IEnumerator PerformJob()
        {
            yield return new WaitForSeconds(5);
            ActionHandler.IsPerformingTask = false;
            ActionHandler.MoveToNextState();
        }
    }
}