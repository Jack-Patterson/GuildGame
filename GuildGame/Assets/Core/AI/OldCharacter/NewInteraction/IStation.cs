namespace com.Halcyon.Core.Interaction.NewInteraction
{
    public interface IStation
    {
        string Type { get; }
        string Name { get; }
        float Duration { get; }
        string AnimationTrigger { get; }

        void UseStation(AI.OldCharacter.NewInteraction.Character character);
    }
}