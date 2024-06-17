using System.Collections.Generic;
using System.Linq;
using com.Halkyon.AI.Character;
using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.AI.Character.Attributes.Needs;
using com.Halkyon.AI.Character.Attributes.Skills;
using com.Halkyon.AI.Character.Attributes.Stats;
using com.Halkyon.AI.Character.StaffJobs;
using TMPro;
using UnityEngine;

namespace com.Halkyon.UI
{
    public class CharacterInfoHandlerUI : MonoBehaviour
    {
        internal Character CurrentlyDisplayedCharacter;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text typeText;
        [SerializeField] private TMP_Text stateText;
        [SerializeField] private GameObject infoContainer;

        [SerializeField] private GameObject needsContainer;
        [SerializeField] private GameObject needsPrefab;
        [SerializeField] private GameObject statsContainer;
        [SerializeField] private GameObject statsPrefab;
        [SerializeField] private GameObject skillsContainer;
        [SerializeField] private GameObject skillsPrefab;

        private bool _isVisible = false;
        private bool _isFirstEnable = true;
        private List<(IAttribute attribute, GameObject go)> _displayedValues = new List<(IAttribute, GameObject)>();

        private void Start()
        {
            gameObject.SetActive(_isVisible);
        }

        private void Update()
        {
            if (!_isVisible) return;

            UpdateText();
        }

        private void OnEnable()
        {
            if (_isFirstEnable)
            {
                _isFirstEnable = false;
                return;
            }

            _isVisible = true;
        }

        private void OnDisable()
        {
            _isVisible = false;
        }

        public void DisplayCharacter(Character character)
        {
            _displayedValues.ForEach(value => Destroy(value.go));
            _displayedValues.Clear();
            CurrentlyDisplayedCharacter = character;
            CreateTextAreas();
            UpdateText();
        }

        private void CreateTextAreas()
        {
            if (CurrentlyDisplayedCharacter is Staff staff)
            {
                needsContainer.SetActive(false);
                skillsContainer.SetActive(false);
                
                foreach (Stat stat in staff.Stats.Stats)
                {
                    CreateAttributeObject(stat, statsPrefab, statsContainer);
                }
            }
            else if (CurrentlyDisplayedCharacter is Adventurer adventurer)
            {
                needsContainer.SetActive(true);
                skillsContainer.SetActive(true);
                
                foreach (Need need in adventurer.Needs.Needs)
                {
                    CreateAttributeObject(need, needsPrefab, needsContainer);
                }
                
                foreach (Stat stat in adventurer.Stats.Stats)
                {
                    CreateAttributeObject(stat, statsPrefab, statsContainer);
                }
                
                foreach (Skill skill in adventurer.Skills.Skills)
                {
                    CreateAttributeObject(skill, skillsPrefab, skillsContainer);
                }
            }
        }

        private void UpdateText()
        {
            nameText.text = CurrentlyDisplayedCharacter.Name;
            stateText.text = CurrentlyDisplayedCharacter.ActionHandler.CurrentState.GetDescription();

            if (CurrentlyDisplayedCharacter is Staff staff)
            {
                typeText.text = staff.CharacterType;
                DisplayAttributes(staff.Stats.Stats, statsPrefab, statsContainer);
            }
            else if (CurrentlyDisplayedCharacter is Adventurer adventurer)
            {
                typeText.text = adventurer.CharacterType;
                DisplayAttributes(adventurer.Needs.Needs, needsPrefab, needsContainer);
                DisplayAttributes(adventurer.Stats.Stats, statsPrefab, statsContainer);
                DisplayAttributes(adventurer.Skills.Skills, skillsPrefab, skillsContainer);
            }
            else
            {
                typeText.text = $"Type: {CurrentlyDisplayedCharacter.CharacterType}";
            }
        }

        private void CreateAttributeObject(IAttribute attribute, GameObject prefab, GameObject container)
        {
            GameObject needObject = Instantiate(prefab, container.transform);
            _displayedValues.Add((attribute, needObject));
        }

        private void DisplayAttributes<T>(List<T> attributes, GameObject prefab, GameObject container) where T: IAttribute
        {
            foreach (T attribute in attributes)
            {
                (IAttribute existingAttribute, GameObject go) = _displayedValues.FirstOrDefault(dv => dv.attribute.Equals(attribute));
                
                if (go == null)
                {
                    CreateAttributeObject(existingAttribute, prefab, container);
                }
                
                List<TMP_Text> texts = go.GetComponentsInChildren<TMP_Text>().ToList();
                

                if (attribute is Need need)
                {
                    texts.Find(text => text.name == "Name").text = need.Name;
                    texts.Find(text => text.name == "Value").text = $"{need.Value:000.0}/{need.MaxValue}";
                }
                else if (attribute is Stat stat)
                {
                    texts.Find(text => text.name == "Name").text = stat.Name;
                    texts.Find(text => text.name == "Value").text = $"{stat.Value}/{stat.MaxValue}";
                }
                else if (attribute is Skill skill)
                {
                    texts.Find(text => text.name == "Name").text = skill.Name;
                    texts.Find(text => text.name == "Level").text = $"{skill.Level}";
                    texts.Find(text => text.name == "Value").text = $"{skill.ProgressPercentage}%";
                }
            }
        }
    }
}