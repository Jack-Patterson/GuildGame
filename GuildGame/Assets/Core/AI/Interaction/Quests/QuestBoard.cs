using System.Collections.Generic;
using System.Linq;
using com.Halkyon.AI.Character.Attributes;

namespace com.Halkyon.AI.Interaction.Quests
{
    public class QuestBoard : ExtendedMonoBehaviour, IInteractable
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
            Register(this);
        }

        public Quest GetAvailableQuest(CharacterRank requesterRank)
        {
            List<Quest> appropriateQuests = AvailableQuests.OrderByDescending(q => q.requiredRank).ToList();
            
            foreach (Quest quest in appropriateQuests)
            {
                if (IsAppropriateRank(requesterRank, quest.requiredRank))
                {
                    AvailableQuests.Remove(quest);
                    return quest;
                }
            }

            return null;
        }

        public void Interact(Character.Character character)
        {
            Quest availableQuest = GetAvailableQuest(character.Rank);
            
            character.ActionHandler.AssignQuest(availableQuest);
        }

        public void Register(IInteractable interactable)
        {
            InteractableManager.Instance.Register(this);
        }

        private bool IsAppropriateRank(CharacterRank requesterRank, CharacterRank questRank)
        {
            if (requesterRank <= CharacterRank.C)
            {
                return questRank == requesterRank ||
                       questRank == requesterRank - 1 ||
                       questRank == requesterRank + 1;
            }
            else
            {
                return questRank == requesterRank ||
                       questRank == requesterRank - 1;
            }
        }
    }
}