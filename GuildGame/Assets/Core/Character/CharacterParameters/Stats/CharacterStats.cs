using UnityEngine;

namespace com.Halcyon.Core.Character.CharacterParameters.Stats
{
    public class CharacterStats
    {
        public float Stamina { get; private set; }
        public float Magic { get; private set; }
        public float Swordsmanship { get; private set; }
        public float Archery { get; private set; }

        public void TrainStat(string stat, float amount)
        {
            switch (stat.ToLower())
            {
                case "stamina":
                    Stamina += amount;
                    break;
                case "magic":
                    Magic += amount;
                    break;
                case "swordsmanship":
                    Swordsmanship += amount;
                    break;
                case "archery":
                    Archery += amount;
                    break;
                default:
                    Debug.LogError("Invalid stat.");
                    break;
            }
        }
    }
}