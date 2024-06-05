﻿using System.Collections;
using com.Halkyon.AI.Character;
using com.Halkyon.AI.Character.Attributes.Skills;
using UnityEngine;

namespace com.Halkyon.AI.Interaction.Stations.SkillStation
{
    public class SkillStationTrainingDummy : SkillStation
    {
        private new void Start()
        {
            base.Start();

            Skill swordsmanship = CharacterManager.Instance.GetSkillById("1");
            Skill spearmanship = CharacterManager.Instance.GetSkillById("10");
            
            ImprovableSkills.Add(swordsmanship);
            ImprovableSkills.Add(spearmanship);
        }
        
        public override void Interact(Character.Character character)
        {
            Skill skillToImprove = character.Skills.GetLowestRequiredSkillForAspiredClass(ImprovableSkills);

            StartCoroutine(ImproveSkill(skillToImprove));
        }

        private IEnumerator ImproveSkill(Skill skill)
        {
            yield return new WaitForSeconds(ImprovementTimeInSeconds);

            print($"{skill.Name} improved!");
            
            skill.ProgressSkill();
        }
    }
}