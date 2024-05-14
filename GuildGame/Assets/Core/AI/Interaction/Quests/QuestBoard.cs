using System.Collections.Generic;

namespace com.Halkyon.AI.Interaction.Quests
{
    public class QuestBoard : ExtendedMonoBehaviour
    {
        private List<Quest> _availableQuests = new();

        public List<Quest> AvailableQuests
        {
            get
            {
                if (_availableQuests == null || _availableQuests.Count == 0)
                {
                    _availableQuests = QuestManager.GetRandomQuests();
                }

                return _availableQuests;
            }
        }

        private void Start()
        {
            foreach (Quest quest in AvailableQuests)
            {
                print($"Quest: {quest.name} - Location: {quest.Location} {quest.locationCoordinates} - " +
                      $"Rank: {quest.requiredRank} - Type: {quest.questType} - Description: {quest.description}");
            }
        }
    }
}