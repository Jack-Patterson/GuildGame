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

        void Start()
        {
            foreach (Quest quest in Quests)
            {
                print($"Quest: {quest.name} - Location: {quest.Location} {quest.locationCoordinates} - Rank: {quest.requiredRank} - Type: {quest.questType} - Description: {quest.description}");
            }
        }

        private static void LoadQuests()
        {
            Quest[] loadedLocations = Resources.LoadAll<Quest>("Quests");
            _quests.AddRange(loadedLocations);
        }
    }
}