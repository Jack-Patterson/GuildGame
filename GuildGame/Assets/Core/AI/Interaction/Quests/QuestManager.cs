using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes;
using UnityEngine;

namespace com.Halkyon.AI.Interaction.Quests
{
    public class QuestManager : ExtendedMonoBehaviour
    {
        private static List<Quest> _quests = new();

        public static List<Quest> Quests
        {
            get
            {
                if (_quests == null || _quests.Count == 0)
                {
                    LoadQuests();
                }

                return _quests;
            }
        }

        private static void LoadQuests()
        {
            Quest[] loadedLocations = Resources.LoadAll<Quest>("Quests");
            _quests.AddRange(loadedLocations);
        }

        public static List<Quest> GetRandomQuests()
        {
            List<Quest> quests = new();

            if (_quests.Count == 0)
            {
                int questsToGet = Random.Range(2, 5);
                System.Random random = new System.Random();

                for (int i = 0; i < questsToGet; i++)
                {
                    Quest quest = GetRandomWeightedQuest(random);
                    quests.Add(quest);
                }
            }

            return quests;
        }
        
        private static Quest GetRandomWeightedQuest(System.Random random)
        {
            int totalWeight = 0;
            List<int> cumulativeWeights = new List<int>();

            foreach (var quest in Quests)
            {
                totalWeight += GetWeightForRank(quest.requiredRank);
                cumulativeWeights.Add(totalWeight);
            }

            int randomValue = random.Next(totalWeight);
            for (int i = 0; i < cumulativeWeights.Count; i++)
            {
                if (randomValue < cumulativeWeights[i])
                {
                    return Quests[i];
                }
            }

            return Quests[^1];
        }

        private static int GetWeightForRank(CharacterRank rank)
        {
            switch (rank)
            {
                case CharacterRank.F: return 50;
                case CharacterRank.E: return 30;
                case CharacterRank.D: return 20;
                case CharacterRank.C: return 10;
                case CharacterRank.B: return 5;
                case CharacterRank.A: return 2;
                case CharacterRank.S: return 1;
                default: return 1;
            }
        }
    }
}