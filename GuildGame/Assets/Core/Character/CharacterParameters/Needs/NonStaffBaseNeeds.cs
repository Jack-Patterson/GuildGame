namespace com.Halcyon.Core.Character.CharacterParameters.Needs
{
    public class NonStaffBaseNeeds : CharacterNeeds
    {
        public Need Hunger { get; } = new();
        public Need Enjoyment { get; } = new();
        
        protected override void UpdateNeeds(float needDecay)
        {
            Hunger.Value -= needDecay;
            Enjoyment.Value -= needDecay;
        }
    }
}