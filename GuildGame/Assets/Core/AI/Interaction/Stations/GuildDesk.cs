using System.Collections;
using System.Collections.Generic;
using com.Halkyon.AI.Character;
using com.Halkyon.AI.Character.StaffJobs;
using com.Halkyon.AI.Character.States;
using com.Halkyon.AI.Interaction.Quests;
using UnityEngine;

namespace com.Halkyon.AI.Interaction.Stations
{
    public class GuildDesk : StaffWorkstation
    {
        private new void Awake()
        {
            base.Awake();
            AddRequiredStaffType<DeskStaff>(1);
        }

        public override void Interact(Character.Character character)
        {
            if (character is Adventurer regularCharacter)
            {
                StartCoroutine(HandleInteraction(regularCharacter));
            }
        }

        private IEnumerator HandleInteraction(Adventurer adventurer)
        {
            print(adventurer.Rank);

            DeskStaff deskStaff = GetFreeStaffMemberOfType<DeskStaff>();
            
            if (deskStaff == null)
            {
                print("No free staff member.", LogType.Warning);
                yield break;
            }

            deskStaff.ActionHandler.QueueState(StaffState.ConstructState<StaffStatePerform, Staff>(deskStaff));
            yield return new WaitUntil(() => deskStaff.IsPerformingTask);
            
            adventurer.IncreaseRank();
            print(adventurer.Rank);

            CharacterState moveState = CharacterState.ConstructState<CharacterStateMove>(adventurer,
                new object[] { FindObjectOfType<QuestBoard>().Position });
            CharacterState interactState = CharacterState.ConstructState<CharacterStateInteract>(adventurer,
                new object[] { FindObjectOfType<QuestBoard>() });
            
            adventurer.ActionHandler.QueueStates(new List<CharacterState> {moveState, interactState});
            yield return null;
        }
    }
}