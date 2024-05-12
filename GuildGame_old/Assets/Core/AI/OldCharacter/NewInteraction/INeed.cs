namespace com.Halcyon.Core.AI.NewInteraction
{
    public interface INeed : IStat
    {
        float DecayRate { get; }
        void Decay(float deltaTime);
    }
}