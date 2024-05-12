using UnityEngine;

namespace com.Halcyon.Core.AI.NewInteraction
{
    public class Hunger : INeed
    {
        public string Name => "Hunger";
        public float Level { get; set; }
        public float DecayRate { get; }

        public Hunger()
        {
            Level = 1;
            DecayRate = 0.01f;
        }

        public void Decay(float deltaTime)
        {
            Level = Mathf.Max(0, Level - DecayRate * deltaTime);
        }
    }

    public class Thirst : INeed
    {
        public string Name => "Thirst";
        public float Level { get; set; }
        public float DecayRate { get; }

        public Thirst()
        {
            Level = 1;
            DecayRate = 0.015f;
        }

        public void Decay(float deltaTime)
        {
            Level = Mathf.Max(0, Level - DecayRate * deltaTime);
        }
    }

    public class Energy : INeed
    {
        public string Name => "Energy";
        public float Level { get; set; }
        public float DecayRate { get; }

        public Energy()
        {
            Level = 1;
            DecayRate = 0.007f;
        }

        public void Decay(float deltaTime)
        {
            Level = Mathf.Max(0, Level - DecayRate * deltaTime);
        }
    }

    public class Swordsmanship : ISkill
    {
        public string Name => "Swordsmanship";
        public float Level { get; set; }
        public float Commonality { get; }


        public Swordsmanship()
        {
            Level = 0;
            Commonality = .65f;
        }
    }

    public class Archery : ISkill
    {
        public string Name => "Archery";
        public float Level { get; set; }
        public float Commonality { get; }

        public Archery()
        {
            Level = 0;
            Commonality = .25f;
        }
    }

    public class Magicraft : ISkill
    {
        public string Name => "Magicraft";
        public float Level { get; set; }
        public float Commonality { get; }

        public Magicraft()
        {
            Level = 0;
            Commonality = .1f;
        }
    }

    public class Stealth : ISkill
    {
        public string Name => "Stealth";
        public float Level { get; set; }
        public float Commonality { get; }

        public Stealth()
        {
            Level = 0;
            Commonality = .45f;
        }
    }
}