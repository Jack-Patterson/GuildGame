using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace com.Halcyon.Core.UI.GameScene
{
    public class GameSceneButton : MonoBehaviour
    {
        [SerializeField] private GameSceneButtonTypes menuButtonType = GameSceneButtonTypes.Save;
        private Button _button;
        
        public GameSceneButtonTypes MenuButtonType => menuButtonType;
        public Button Button => _button;

        internal void Initialize(UnityAction method)
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(method);
        }
    }
}