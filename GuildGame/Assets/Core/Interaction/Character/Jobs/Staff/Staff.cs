using com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats;
using com.Halcyon.Core.Interaction.InteractableObjects;

namespace com.Halcyon.Core.Interaction.Character.Jobs.Staff
{
    public abstract class Staff<TStats> : Character<TStats> where TStats : StaffStats, new()
    {
        protected InteractableObject AssignedWorkstation;
    }
}