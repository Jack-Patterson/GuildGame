using com.Halcyon.Core.AI.InteractableObjects;
using com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats;
using com.Halcyon.Core.Interaction.InteractableObjects;

namespace com.Halcyon.Core.AI.OldCharacter.Character.Jobs.Staff
{
    public abstract class Staff<TStats> : Character<TStats> where TStats : StaffStats, new()
    {
        protected InteractableObject AssignedWorkstation;
    }
}