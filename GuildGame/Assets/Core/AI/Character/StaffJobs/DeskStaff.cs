using com.Halkyon.AI.Interaction.Stations;

namespace com.Halkyon.AI.Character.StaffJobs
{
    public class DeskStaff : Staff
    {
        public override string CharacterId => "npc_staff_desk";
        public override string CharacterType => "Desk Staff";
        
        private new void Start()
        {
            base.Start();
            Workstation = FindObjectOfType<GuildDesk>();
            Workstation.AssignStaff(this);
        }
    }
}