using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace com.Halcyon.Core.UI
{
    public class MainMenuButton : MonoBehaviour
    {
        [SerializeField] private MainMenuButtonTypes menuButtonType = MainMenuButtonTypes.Continue;
        private Button _button;

        public MainMenuButtonTypes MenuButtonType => menuButtonType;
        public Button Button => _button;

        internal void Initialize(UnityAction method)
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(method);
        }
    }
}