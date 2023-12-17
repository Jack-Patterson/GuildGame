using com.Halcyon.Core.Manager;
using com.Halcyon.Core.Services.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.Halcyon.Core.Input
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private InputService _inputService;
        private InputAction _movement;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            GameInitializer.GameInitializationComplete += AssignInputService;
        }

        private void AssignInputService()
        {
            _inputService = GameManager.Instance.GameParameters.InputService as InputService;
        }

        #region Movement

        private void OnMovePerformed(InputAction.CallbackContext eventAction)
        {
            Vector2 moveDirection = eventAction.ReadValue<Vector2>();
            // print(moveDirection);
            _inputService.InvokeMovePerformed(moveDirection);
        }

        private void OnRotatePerformed(InputAction.CallbackContext eventAction)
        {
            float rotateDirection = eventAction.ReadValue<float>();
            _inputService.InvokeRotatePerformed(rotateDirection);
        }

        #endregion

        #region Mouse Actions

        private void OnMouse1PressedStarted(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse1PressStarted();
        }
        
        private void OnMouse1PressPressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse1PressPerformed();
        }

        private void OnMouse1PressedEnded(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse1PressEnded();
        }

        private void OnMouse2PressedStarted(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse2PressStarted();
        }

        private void OnMouse2PressedEnded(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse2PressEnded();
        }

        private void OnMouse3PressedStarted(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse3PressStarted();
        }

        private void OnMouse3PressedEnded(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMouse3PressEnded();
        }

        private void OnMouseMoveStarted(InputAction.CallbackContext eventAction)
        {
            Vector2 mouseMoveAmount = eventAction.ReadValue<Vector2>();
            _inputService.InvokeMouseMoveStarted(mouseMoveAmount);
        }

        private void OnMouseScrollPerformed(InputAction.CallbackContext eventAction)
        {
            float mouseScrollAmount = eventAction.ReadValue<float>();
            _inputService.InvokeMouse3ScrollPerformed(mouseScrollAmount);
        }

        private void OnMousePositionPerformed(InputAction.CallbackContext eventAction)
        {
            Vector2 mousePosition = eventAction.ReadValue<Vector2>();
            _inputService.InvokeMousePositionPerformed(mousePosition);
        }
        
        private void OnMousePositionPerformedWithMouse1(InputAction.CallbackContext eventAction)
        {
            Vector2 mousePosition = eventAction.ReadValue<Vector2>();
            _inputService.InvokeMousePositionPerformedWithMouse1(mousePosition);
        }

        #endregion

        #region Time Controls

        private void OnTimePausePressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeTimePausePressStarted();
        }

        private void OnTimeOnePressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeTimeOneSpeedPressStarted();
        }

        private void OnTimeTwoPressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeTimeTwoSpeedPressStarted();
        }

        private void OnTimeThreePressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeTimeThreeSpeedPressStarted();
        }

        private void OnTimeTogglePressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeTimeTogglePressStarted();
        }

        #endregion

        private void OnMenuPressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeMenuPressStarted();
        }

        private void OnToggleBuildPressed(InputAction.CallbackContext eventAction)
        {
            _inputService.InvokeToggleBuildStarted();
        }

        private void OnEnable()
        {
            _playerInputs.PlayerControls.Enable();

            _playerInputs.PlayerControls.Move.performed += OnMovePerformed;
            _playerInputs.PlayerControls.Rotate.performed += OnRotatePerformed;

            _playerInputs.PlayerControls.Mouse1Pressed.started += OnMouse1PressedStarted;
            _playerInputs.PlayerControls.Mouse1Pressed.performed += OnMouse1PressPressed;
            _playerInputs.PlayerControls.Mouse1Pressed.canceled += OnMouse1PressedEnded;
            _playerInputs.PlayerControls.Mouse2Pressed.started += OnMouse2PressedStarted;
            _playerInputs.PlayerControls.Mouse2Pressed.canceled += OnMouse2PressedEnded;
            _playerInputs.PlayerControls.Mouse3Pressed.started += OnMouse3PressedStarted;
            _playerInputs.PlayerControls.Mouse3Pressed.canceled += OnMouse3PressedEnded;
            _playerInputs.PlayerControls.Mouse3Scroll.performed += OnMouseScrollPerformed;
            _playerInputs.PlayerControls.MouseMove.started += OnMouseMoveStarted;
            _playerInputs.PlayerControls.MousePosition.performed += OnMousePositionPerformed;

            _playerInputs.PlayerControls.TimePause.started += OnTimePausePressed;
            _playerInputs.PlayerControls.Time1Speed.started += OnTimeOnePressed;
            _playerInputs.PlayerControls.Time2Speed.started += OnTimeTwoPressed;
            _playerInputs.PlayerControls.Time3Speed.started += OnTimeThreePressed;
            _playerInputs.PlayerControls.ToggleTimePause.started += OnTimeTogglePressed;

            _playerInputs.PlayerControls.Menu.started += OnMenuPressed;
            _playerInputs.PlayerControls.ToggleBuild.started += OnToggleBuildPressed;
        }

        private void OnDisable()
        {
            _playerInputs.PlayerControls.Move.performed -= OnMovePerformed;
            _playerInputs.PlayerControls.Rotate.performed -= OnRotatePerformed;

            _playerInputs.PlayerControls.Mouse1Pressed.started -= OnMouse1PressedStarted;
            _playerInputs.PlayerControls.Mouse1Pressed.canceled -= OnMouse1PressedEnded;
            _playerInputs.PlayerControls.Mouse2Pressed.started -= OnMouse2PressedStarted;
            _playerInputs.PlayerControls.Mouse2Pressed.canceled -= OnMouse2PressedEnded;
            _playerInputs.PlayerControls.Mouse3Pressed.started -= OnMouse3PressedStarted;
            _playerInputs.PlayerControls.Mouse3Pressed.canceled -= OnMouse3PressedEnded;
            _playerInputs.PlayerControls.Mouse3Scroll.performed -= OnMouseScrollPerformed;
            _playerInputs.PlayerControls.MouseMove.started -= OnMouseMoveStarted;
            _playerInputs.PlayerControls.MousePosition.performed -= OnMousePositionPerformed;

            _playerInputs.PlayerControls.TimePause.started -= OnTimePausePressed;
            _playerInputs.PlayerControls.Time1Speed.started -= OnTimeOnePressed;
            _playerInputs.PlayerControls.Time2Speed.started -= OnTimeTwoPressed;
            _playerInputs.PlayerControls.Time3Speed.started -= OnTimeThreePressed;
            _playerInputs.PlayerControls.ToggleTimePause.started -= OnTimeTogglePressed;

            _playerInputs.PlayerControls.Menu.started -= OnMenuPressed;
            _playerInputs.PlayerControls.ToggleBuild.started -= OnToggleBuildPressed;

            _playerInputs.PlayerControls.Disable();
        }
    }
}