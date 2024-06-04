using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction.Quests;

namespace com.Halkyon.AI.Interaction.Stations
{
    public class GuildDesk : InteractableMonoBehaviour
    {
        public override void Interact(Character.Character character)
        {
            print(character.Rank);
            character.IncreaseRank();
            print(character.Rank);

            character.ActionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(character,
                new object[] { FindObjectOfType<QuestBoard>().Position }));
            character.ActionHandler.QueueState(CharacterState.ConstructState<CharacterStateInteract>(character,
                new object[] { FindObjectOfType<QuestBoard>() }));
        }
    }
}