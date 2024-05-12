namespace com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats
{
    public class NonStaffBaseStats : CharacterStats
    {
        public Stat Stamina { get; } = new();
        public Stat Magic { get; } = new();
        public Stat Swordsmanship { get; } = new();
        public Stat Archery { get; } = new();
    }
}