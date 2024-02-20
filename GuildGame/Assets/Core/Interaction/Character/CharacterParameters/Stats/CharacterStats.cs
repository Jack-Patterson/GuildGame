namespace com.Halcyon.Core.Interaction.Character.CharacterParameters.Stats
{
    public class CharacterStats
    {
        public void TrainStat(Stat stat, float amount)
        {
            stat.Value += amount;
        }
    }
}