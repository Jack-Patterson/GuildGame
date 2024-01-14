using System.Collections.Generic;
using System.Linq;
using com.Halcyon.Core.Manager;
using UnityEngine;
using UnityEngine.Events;

namespace com.Halcyon.Core.UI.GameScene
{
    public class GameSceneUiController : MonoBehaviour
    {
        [SerializeField] private List<GameSceneButton> buttons;
        [SerializeField] private Builder.Builder builder;

        private void Start()
        {
            buttons = FindAndInitializeButtons();
        }
        
        private List<GameSceneButton> FindAndInitializeButtons()
        {
            List<GameSceneButton> gameSceneButtons = GetComponentsInChildren<GameSceneButton>().ToList();
            foreach (GameSceneButton mmb in gameSceneButtons)
            {
                mmb.Initialize(AddActionBasedOnButtonType(mmb.MenuButtonType));
            }

            return gameSceneButtons;
        }
        
        private UnityAction AddActionBasedOnButtonType(GameSceneButtonTypes buttonTypes)
        {
            switch (buttonTypes)
            {
                case GameSceneButtonTypes.Save:
                    return SaveAction;
                case GameSceneButtonTypes.Load:
                    return LoadAction;
                case GameSceneButtonTypes.Floor1:
                    return () => FloorAction(1);
                case GameSceneButtonTypes.Floor2:
                    return () => FloorAction(2);
                case GameSceneButtonTypes.Floor3:
                    return () => FloorAction(3);
                case GameSceneButtonTypes.Exit:
                default:
                    return null;
            }
        }

        private void SaveAction()
        {
            print(GameManager.Instance.DataHolder.SaveData("GameSaveTest"));
        }
        
        private void LoadAction()
        {
            GameManager.Instance.DataHolder = GameManager.Instance.DataHolder.LoadData("GameSaveTest");
        }

        private void FloorAction(int value)
        {
            builder.FloorHandler.CurrentFloor = value;
        }
        
    }
}
