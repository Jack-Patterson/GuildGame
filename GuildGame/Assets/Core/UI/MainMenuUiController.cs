using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace com.Halcyon.Core.UI
{
    public class MainMenuUiController : MonoBehaviour
    {
        [SerializeField] private List<MainMenuButton> buttons;

        private void Start()
        {
            buttons = FindAndInitializeButtons();
        }

        private List<MainMenuButton> FindAndInitializeButtons()
        {
            List<MainMenuButton> mainMenuButtons = GetComponentsInChildren<MainMenuButton>().ToList();
            foreach (MainMenuButton mmb in mainMenuButtons)
            {
                mmb.Initialize(AddActionBasedOnButtonType(mmb.MenuButtonType));
            }

            return mainMenuButtons;
        }

        private UnityAction AddActionBasedOnButtonType(MainMenuButtonTypes buttonTypes)
        {
            switch (buttonTypes)
            {
                case MainMenuButtonTypes.Continue:
                    return ContinueButtonAction;
                case MainMenuButtonTypes.NewGame:
                    return NewGameButtonAction;
                case MainMenuButtonTypes.Load:
                    return LoadButtonAction;
                case MainMenuButtonTypes.Settings:
                    return SettingsButtonAction;
                case MainMenuButtonTypes.Exit:
                    return ExitButtonAction;
                case MainMenuButtonTypes.Discord:
                    return DiscordButtonAction;
                default:
                    return null;
            }
        }

        private void ContinueButtonAction()
        {
            print("Continue");
        }

        private void NewGameButtonAction()
        {
            print("New Game");
        }

        private void LoadButtonAction()
        {
            print("Load Game");
        }

        private void SettingsButtonAction()
        {
            print("Settings");
        }

        private void ExitButtonAction()
        {
#if UNITY_EDITOR
            print("Exiting application via the Main Menu in the Editor.");
            EditorApplication.isPlaying = false;
#else
            print("Exiting application via the Main Menu in the built game.");
            Application.Quit();
#endif
        }
        
        private void DiscordButtonAction()
        {
            print("Opening discord invitation link.");
            Application.OpenURL(Constants.DiscordInviteLink);
        }
    }
}