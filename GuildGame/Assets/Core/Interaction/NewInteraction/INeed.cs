namespace com.Halcyon.Core.Interaction.NewInteraction
{
    public interface INeed : IStat
    {
        float DecayRate { get; }
        void Decay(float deltaTime);
    }
}