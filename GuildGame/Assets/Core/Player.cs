﻿using System;
using com.Halkyon.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.Halkyon
{
    public class Player : ExtendedMonoBehaviour
    {
        private void Start()
        {
            InputActions inputActions = FindObjectOfType<InputActions>();
            inputActions.StrategyPlayer.Move.performed += Move;
            inputActions.StrategyPlayer.Jump.performed += Jump;
            inputActions.StrategyPlayer.Mouse1Click.performed += Mouse1Click;
            inputActions.StrategyPlayer.Mouse2Click.performed += Mouse2Click;
            inputActions.StrategyPlayer.Mouse3Click.performed += Mouse3Click;
            inputActions.StrategyPlayer.Mouse4Click.performed += Mouse4Click;
            inputActions.StrategyPlayer.Mouse5Click.performed += Mouse5Click;
            inputActions.StrategyPlayer.Mouse3Scroll.performed += Mouse3Scroll;
            inputActions.StrategyPlayer.Rotate.performed += Rotate;
        }

        private void Rotate(InputAction.CallbackContext obj)
        {
            print("Rotate " + obj.ReadValue<float>());
        }

        private void Mouse3Scroll(InputAction.CallbackContext obj)
        {
            print("Mouse 3 Scroll " + obj.ReadValue<float>());
        }

        private void Mouse5Click(InputAction.CallbackContext obj)
        {
            print("Mouse 5 Click");
        }

        private void Mouse4Click(InputAction.CallbackContext obj)
        {
            print("Mouse 4 Click");
        }

        private void Mouse3Click(InputAction.CallbackContext obj)
        {
            print("Mouse 3 Click");
        }

        private void Mouse2Click(InputAction.CallbackContext obj)
        {
            print("Mouse 2 Click");
        }

        private void Mouse1Click(InputAction.CallbackContext obj)
        {
            print("Mouse 1 Click");
        }

        private void Move(InputAction.CallbackContext obj)
        {
            print("Move " + obj.ReadValue<Vector2>());
        }

        public void Jump(InputAction.CallbackContext obj)
        {
            print("Jump");
        }
    }
}