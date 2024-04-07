using System.Collections.Generic;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.NewInteraction
{
    public class CharacterNew : MonoBehaviour
    {
        private void Start()
        {
            print(Services.Serialization.Constants.ExampleVariable);
            List<ISkill> skillPool = new List<ISkill>
            {
                new Swordsmanship(),
                new Archery(),
                new Magicraft(),
                new Stealth()
            };
            List<ISkill> selectedSkills = SelectCharacterSkills(skillPool);

            foreach (ISkill skill in selectedSkills)
            {
                print(skill.Name);
            }
        }

        public List<ISkill> SelectCharacterSkills(List<ISkill> skillPool)
        {
            float totalCommonality = 0f;
            foreach (var skill in skillPool)
            {
                totalCommonality += skill.Commonality;
            }

            List<ISkill> selectedSkills = new List<ISkill>();
            int itemsToSelect = DetermineItemsToSelect();

            while (selectedSkills.Count < itemsToSelect)
            {
                float randomPoint = Random.value * totalCommonality;
                foreach (var skill in skillPool)
                {
                    if (selectedSkills.Contains(skill)) continue; // Skip already selected skills

                    if (randomPoint < skill.Commonality)
                    {
                        selectedSkills.Add(skill);
                        break; // Exit the loop once a skill is added
                    }
                    randomPoint -= skill.Commonality;
                }
            }

            return selectedSkills;
        }

        private int DetermineItemsToSelect()
        {
            float chance = Random.value;
            if (chance < 0.25f) return 3; // 5% chance for three items
            else if (chance < 0.5f) return 2; // 20% chance for two items
            return 1; // Default to one item
        }
    }
}