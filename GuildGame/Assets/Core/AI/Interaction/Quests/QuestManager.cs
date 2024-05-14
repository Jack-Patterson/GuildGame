using System.Collections.Generic;
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
                for (int i = 0; i < questsToGet; i++)
                {
                    Quest quest = Quests[Random.Range(0, Quests.Count)];
                    quests.Add(quest);
                }
            }
            
            return quests;
        }
    }
}