using System.Collections.Generic;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction;
using com.Halkyon.AI.Interaction.Quests;
using com.Halkyon.AI.Interaction.Stations;

namespace com.Halkyon.AI.Character.Actions
{
    public class AdventurerActionHandler : CharacterActionHandler
    {
        protected override void FindInitialTask()
        {
            if (Character is Adventurer { Rank: CharacterRank.None })
            {
                GuildDesk guildDesk = InteractableManager.Instance.GetClosestInteractableOfType<GuildDesk>(Position);
                CharacterStateMove moveState =
                    CharacterState.ConstructState<CharacterStateMove>(Character, new object[] { guildDesk.Position });
                CharacterStateInteract interactState =
                    CharacterState.ConstructState<CharacterStateInteract>(Character, new object[] { guildDesk, true });
            
                QueueStates(
                    new List<(CharacterState state, object[] args)> { (moveState, null), (interactState, null) });
            }
            else
            {
                DetermineNextState();
            }
        }

        protected override void DetermineNextState(bool questNotFound = false)
        {
            // QueueStates(FindAndInteractWithInteractable<SkillStation>());
            // return;

            if (Character is not Adventurer adventurer) return;
            Need lowestNeed = adventurer.Needs.GetLowestNeed();
            if (lowestNeed != null && lowestNeed.Value < (lowestNeed.MaxValue * 0.4f))
            {
                // Find appropriate station
                print("Lowest need is " + lowestNeed);
                return;
            }

            if (!questNotFound && CanTakeQuest())
            {
                if (lowestNeed != null && lowestNeed.Value < (lowestNeed.MaxValue * 0.7f))
                {
                    // Find appropriate station
                }

                List<CharacterState> states = FindAndInteractWithInteractable<QuestBoard>();
                QueueStates(states);
                return;
            }

            // if lacking in items, buy items. May also choose to buy certain upgrade items
            // if lacking money or doesn't need items train skills

            Skill lowestSkill = adventurer.Skills.GetLowestRequiredSkillForAspiredClass();
            // Find appropriate station and train skill}
        }
    }
}