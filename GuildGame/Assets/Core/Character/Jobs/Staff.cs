using com.Halcyon.Core.Character.CharacterParameters.Stats;

namespace com.Halcyon.Core.Character.Jobs
{
    public abstract class Staff<TStats> : Character<TStats> where TStats : StaffStats, new()
    {
    }
}