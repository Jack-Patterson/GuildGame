using System;
using com.Halkyon.AI.Character;
using TMPro;
using UnityEngine;

namespace com.Halkyon.UI
{
    public class CharacterInfoHandlerUI : MonoBehaviour
    {
        internal Character CurrentlyDisplayedCharacter;
        private bool _isVisible = false;
        private bool _isFirstEnable = true;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text typeText;
        [SerializeField] private TMP_Text stateText;
        [SerializeField] private GameObject infoContainer;

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
            CurrentlyDisplayedCharacter = character;
            UpdateText();
        }

        private void UpdateText()
        {
            nameText.text = CurrentlyDisplayedCharacter.Name;
            stateText.text = CurrentlyDisplayedCharacter.ActionHandler.CurrentState.GetDescription();
            
            if (CurrentlyDisplayedCharacter is Staff staff)
            {
                typeText.text = $"Type: {staff.CharacterType}";
            }
            else if (CurrentlyDisplayedCharacter is Adventurer adventurer)
            {
                typeText.text = $"Type: {adventurer.CharacterType}";
            }
            else
            {
                typeText.text = $"Type: {CurrentlyDisplayedCharacter.CharacterType}";
            }
        }
    }
}