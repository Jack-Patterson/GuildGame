using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.Halcyon.Core.Input
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private InputAction _movement;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            
        }

        private void OnMouse1Pressed(InputAction.CallbackContext eventAction)
        {
            print("Mouse1 Pressed");
        }
        
        private void OnMouse2Pressed(InputAction.CallbackContext eventAction)
        {
            print("Mouse2 Pressed");
        }
        
        private void OnMouse3Pressed(InputAction.CallbackContext eventAction)
        {
            print("Mouse3 Pressed");
        }
        
        private void OnTimePausePressed(InputAction.CallbackContext eventAction)
        {
            print("Time0 Pressed");
        }
        
        private void OnTimeOnePressed(InputAction.CallbackContext eventAction)
        {
            print("Time1 Pressed");
        }
        
        private void OnTimeTwoPressed(InputAction.CallbackContext eventAction)
        {
            print("Time2 Pressed");
        }
        
        private void OnTimeThreePressed(InputAction.CallbackContext eventAction)
        {
            print("Time3 Pressed");
        }
        
        private void OnTimeTogglePressed(InputAction.CallbackContext eventAction)
        {
            print("TimeToggle Pressed");
        }

        private void OnMovePerformed(InputAction.CallbackContext eventAction)
        {
            print(eventAction.ReadValue<Vector2>());
        }
        
        private void OnRotatePerformed(InputAction.CallbackContext eventAction)
        {
            print(eventAction.ReadValue<float>());
        }
        
        private void OnMenuPressed(InputAction.CallbackContext eventAction)
        {
            print("Menu/Esc pressed");
        }
        
        private void OnMouseMove(InputAction.CallbackContext eventAction)
        {
            print("MouseMoved");
            print(eventAction.ReadValue<Vector2>());
        }
        
        private void OnMouseScroll(InputAction.CallbackContext eventAction)
        {
            print("MouseScrolled");
            print(eventAction.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _playerInputs.PlayerControls.Enable();
            
            _playerInputs.PlayerControls.Move.performed += OnMovePerformed;
            _playerInputs.PlayerControls.Rotate.performed += OnRotatePerformed;
            
            _playerInputs.PlayerControls.Mouse1Pressed.started += OnMouse1Pressed;
            _playerInputs.PlayerControls.Mouse2Pressed.started += OnMouse2Pressed;
            _playerInputs.PlayerControls.Mouse3Pressed.started += OnMouse3Pressed;

            _playerInputs.PlayerControls.Mouse3Scroll.performed += OnMouseScroll;
            _playerInputs.PlayerControls.MouseMove.started += OnMouseMove;
            
            _playerInputs.PlayerControls.TimePause.started += OnTimePausePressed;
            _playerInputs.PlayerControls.Time1Speed.started += OnTimeOnePressed;
            _playerInputs.PlayerControls.Time2Speed.started += OnTimeTwoPressed;
            _playerInputs.PlayerControls.Time3Speed.started += OnTimeThreePressed;
            _playerInputs.PlayerControls.ToggleTimePause.started += OnTimeTogglePressed;

            _playerInputs.PlayerControls.Menu.started += OnMenuPressed;
        }

        private void OnDisable()
        {
            _playerInputs.PlayerControls.Move.performed -= OnMovePerformed;
            _playerInputs.PlayerControls.Rotate.performed -= OnRotatePerformed;
            
            _playerInputs.PlayerControls.Mouse1Pressed.started -= OnMouse1Pressed;
            _playerInputs.PlayerControls.Mouse2Pressed.started -= OnMouse2Pressed;
            _playerInputs.PlayerControls.Mouse3Pressed.started -= OnMouse3Pressed;
            
            _playerInputs.PlayerControls.Mouse3Scroll.performed -= OnMouseScroll;
            _playerInputs.PlayerControls.MouseMove.started -= OnMouseMove;
            
            _playerInputs.PlayerControls.TimePause.started -= OnTimePausePressed;
            _playerInputs.PlayerControls.Time1Speed.started -= OnTimeOnePressed;
            _playerInputs.PlayerControls.Time2Speed.started -= OnTimeTwoPressed;
            _playerInputs.PlayerControls.Time3Speed.started -= OnTimeThreePressed;
            _playerInputs.PlayerControls.ToggleTimePause.started -= OnTimeTogglePressed;
            
            _playerInputs.PlayerControls.Menu.started -= OnMenuPressed;
            
            _playerInputs.PlayerControls.Disable();
        }
    }
}