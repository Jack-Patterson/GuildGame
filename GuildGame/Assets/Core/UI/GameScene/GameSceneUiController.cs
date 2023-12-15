using System.Collections.Generic;
using System.Linq;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Building;
using com.Halcyon.Core.Manager;
using UnityEngine;
using UnityEngine.Events;

namespace com.Halcyon.Core.UI.GameScene
{
    public class GameSceneUiController : MonoBehaviour
    {
        [SerializeField] private List<GameSceneButton> buttons;
        [SerializeField] private Builder builder;

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
                case GameSceneButtonTypes.Exit:
                default:
                    return null;
            }
        }

        private void SaveAction()
        {
            print(builder.SaveAction("builderitems"));
        }
        
        private void LoadAction()
        {
            var items = builder.LoadAction<List<SerializableBuilderItem>>("builderitems");
            print(items);
            SerializableBuilderItem.InstantiateItemsAndReferences(items, builder);
        }
    }
}
