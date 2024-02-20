using com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats;

namespace com.Halcyon.Core.Interaction.Character.Jobs.Staff
{
    public abstract class Staff<TStats> : Character<TStats> where TStats : StaffStats, new()
    {
    }
}