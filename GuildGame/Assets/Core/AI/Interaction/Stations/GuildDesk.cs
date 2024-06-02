using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction.Quests;

namespace com.Halkyon.AI.Interaction.Stations
{
    public class GuildDesk : ExtendedMonoBehaviour, IInteractable
    {
        private void Start()
        {
            Register(this);
        }

        public void Interact(Character.Character character)
        {
            print(character.Rank);
            character.IncreaseRank();
            print(character.Rank);

            character.ActionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(character,
                new object[] { FindObjectOfType<QuestBoard>().Position }));
            character.ActionHandler.QueueState(CharacterState.ConstructState<CharacterStateInteract>(character,
                new object[] { FindObjectOfType<QuestBoard>() }));
        }

        public void Register(IInteractable interactable)
        {
            InteractableManager.Instance.Register(this);
        }
    }
}