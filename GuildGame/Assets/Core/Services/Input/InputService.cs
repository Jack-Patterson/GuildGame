#nullable enable

using System;
using com.Halcyon.API.Services.Input;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Services.Input
{
    public class InputService : IInputService
    {
        public event Action<Vector2>? MovePerformed;
        public event Action<float>? RotatePerformed;

        public event Action? Mouse1PressStarted;
        public event Action? Mouse1PressPerformed;
        public event Action? Mouse1PressEnded;
        public event Action? Mouse2PressStarted;
        public event Action? Mouse2PressEnded;
        public event Action? Mouse3PressStarted;
        public event Action? Mouse3PressEnded;
        public event Action<float>? Mouse3ScrollPerformed;
        public event Action<Vector2>? MouseMoveStarted;
        public event Action<Vector2>? MousePositionPerformed;
        public event Action<Vector2>? MousePositionPerformedWithMouse1;

        public event Action? TimePausePressStarted;
        public event Action? TimeOneSpeedPressStarted;
        public event Action? TimeTwoSpeedPressStarted;
        public event Action? TimeThreeSpeedPressStarted;
        public event Action? TimeTogglePressStarted;

        public event Action? MenuPressStarted;
        public event Action? ToggleBuildStarted;

        public void InvokeMovePerformed(Vector2 value)
        {
            MovePerformed?.Invoke(value);
        }

        public void InvokeRotatePerformed(float value)
        {
            RotatePerformed?.Invoke(value);
        }

        public void InvokeMouse1PressStarted()
        {
            Mouse1PressStarted?.Invoke();
        }

        public void InvokeMouse1PressPerformed()
        {
            Mouse1PressPerformed?.Invoke();
        }

        public void InvokeMouse1PressEnded()
        {
            Mouse1PressEnded?.Invoke();
        }

        public void InvokeMouse2PressStarted()
        {
            Mouse2PressStarted?.Invoke();
        }

        public void InvokeMouse2PressEnded()
        {
            Mouse2PressEnded?.Invoke();
        }

        public void InvokeMouse3PressStarted()
        {
            Mouse3PressStarted?.Invoke();
        }

        public void InvokeMouse3PressEnded()
        {
            Mouse3PressEnded?.Invoke();
        }

        public void InvokeMouse3ScrollPerformed(float value)
        {
            Mouse3ScrollPerformed?.Invoke(value);
        }

        public void InvokeMouseMoveStarted(Vector2 value)
        {
            MouseMoveStarted?.Invoke(value);
        }

        public void InvokeMousePositionPerformed(Vector2 value)
        {
            MousePositionPerformed?.Invoke(value);
        }
        
        public void InvokeMousePositionPerformedWithMouse1(Vector2 value)
        {
            MousePositionPerformedWithMouse1?.Invoke(value);
        }

        public void InvokeTimePausePressStarted()
        {
            TimePausePressStarted?.Invoke();
        }

        public void InvokeTimeOneSpeedPressStarted()
        {
            TimeOneSpeedPressStarted?.Invoke();
        }

        public void InvokeTimeTwoSpeedPressStarted()
        {
            TimeTwoSpeedPressStarted?.Invoke();
        }

        public void InvokeTimeThreeSpeedPressStarted()
        {
            TimeThreeSpeedPressStarted?.Invoke();
        }

        public void InvokeTimeTogglePressStarted()
        {
            TimeTogglePressStarted?.Invoke();
        }

        public void InvokeMenuPressStarted()
        {
            MenuPressStarted?.Invoke();
        }

        public void InvokeToggleBuildStarted()
        {
            ToggleBuildStarted?.Invoke();
        }
    }
}