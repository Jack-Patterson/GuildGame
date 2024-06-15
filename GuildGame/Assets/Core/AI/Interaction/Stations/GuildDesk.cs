using com.Halkyon.AI.Character;
using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction.Quests;

namespace com.Halkyon.AI.Interaction.Stations
{
    public class GuildDesk : InteractableMonoBehaviour
    {
        public override void Interact(Character.Character character)
        {
            if (character is Adventurer regularCharacter)
            {
                print(regularCharacter.Rank);
                regularCharacter.IncreaseRank();
                print(regularCharacter.Rank);
                
                character.ActionHandler.QueueState(CharacterState.ConstructState<CharacterStateMove>(character,
                    new object[] { FindObjectOfType<QuestBoard>().Position }));
                character.ActionHandler.QueueState(CharacterState.ConstructState<CharacterStateInteract>(character,
                    new object[] { FindObjectOfType<QuestBoard>() }));
            }
        }
    }
}