using System.Collections.Generic;

namespace com.Halkyon.AI.Character.Attributes.Stats
{
    public class CharacterStats : CharacterSubscriber
    {
        public List<Stat> Stats { get; } = new();

        private void Awake()
        {
            CharacterManager.OnStatAdded += OnStatAdded;
            CharacterManager.OnStatRemoved += OnStatRemoved;
        }
        
        private void Start()
        {
            foreach (Stat stat in Stats)
            {
                print(stat);
            }
        }

        private void OnStatAdded(Stat stat)
        {
            Stats.Add(stat);
            stat.OnStatDepleted += OnStatDepleted;
        }

        private void OnStatRemoved(Stat stat)
        {
            Stats.Remove(stat);
            stat.OnStatDepleted = null;
        }

        private void OnStatDepleted(Stat stat)
        {
            print($"Stat {stat.Name} fully depleted!");
        }

        protected override void OnUnsubscribeCharacterEvent()
        {
            Stats.ForEach(stat => stat.OnStatDepleted = null);
            print("Stats Unsubscribed!");
        }
    }
}