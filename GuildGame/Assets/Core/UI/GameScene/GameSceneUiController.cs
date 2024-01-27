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
            List<GameSceneToggle> gameSceneToggles = GetComponentsInChildren<GameSceneToggle>().ToList();
            foreach (GameSceneButton gameSceneButton in gameSceneButtons)
            {
                gameSceneButton.Initialize(AddActionBasedOnButtonType(gameSceneButton.MenuButtonType));
            }
            foreach (GameSceneToggle gameSceneToggle in gameSceneToggles)
            {
                gameSceneToggle.Initialize(AddActionBasedOnToggleType(gameSceneToggle.MenuToggleType));
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
        
        private UnityAction<bool> AddActionBasedOnToggleType(GameSceneToggleTypes buttonTypes)
        {
            switch (buttonTypes)
            {
                case GameSceneToggleTypes.UseWallBuilder:
                    return GridBuilderToggleAction;
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
        
        private void GridBuilderToggleAction(bool value)
        {
            builder.ToggleCurrentlyActiveGridBuilder();
        }
    }
}
