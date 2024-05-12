using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace com.Halcyon.Core.UI.GameScene
{
    public class GameSceneToggle : MonoBehaviour
    {
        [SerializeField] private GameSceneToggleTypes menuToggleType = GameSceneToggleTypes.UseWallBuilder;
        private Toggle _toggle;
        
        public GameSceneToggleTypes MenuToggleType => menuToggleType;
        public Toggle Toggle => _toggle;
        
        internal void Initialize(UnityAction<bool> method)
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(method);
        }
    }
}