using System.Collections.Generic;
using com.Halkyon.Input;

namespace com.Halkyon.AI.Character.Attributes.Stats
{
    public class CharacterStats : CharacterSubscriber
    {
        public List<Stat> Stats { get; private set; } = new();

        private void Start()
        {
            // InputActions inputActions = FindObjectOfType<InputActions>();
            // inputActions.StrategyPlayer.Mouse3Click.performed += _ =>
            // {
            //     Stats[0].Amount -= 10;
            //     print($"Stat {Stats[0].Name} progress: " + Stats[0].Amount);
            // };
            //
            // Stats = Stat.BaseStats;
            // Stats[0].OnStatDepleted += _ => GetComponent<Character>().InvokeUnsubscribeCharacterEvents();
            SubscribeToStatEvents();
        }
        
        private void SubscribeToStatEvents()
        {
            foreach (Stat stat in Stats)
            {
                stat.OnStatDepleted += OnStatDepleted;
            }
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