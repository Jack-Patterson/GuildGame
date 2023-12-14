using com.Halcyon.API.Services.Serialization;
using UnityEngine;

namespace com.Halcyon.API.Services.Input
{
    public interface IInputService
    {
        event Action<Vector2> MovePerformed;
        event Action<float> RotatePerformed;

        event Action Mouse1PressStarted;
        event Action Mouse1PressPerformed;
        event Action Mouse1PressEnded;
        event Action Mouse2PressStarted;
        event Action Mouse2PressEnded;
        event Action Mouse3PressStarted;
        event Action Mouse3PressEnded;
        event Action<float> Mouse3ScrollPerformed;
        event Action<Vector2> MouseMoveStarted;
        event Action<Vector2> MousePositionPerformed;
        event Action<Vector2> MousePositionPerformedWithMouse1;

        event Action TimePausePressStarted;
        event Action TimeOneSpeedPressStarted;
        event Action TimeTwoSpeedPressStarted;
        event Action TimeThreeSpeedPressStarted;
        event Action TimeTogglePressStarted;
        
        event Action MenuPressStarted;
        event Action ToggleBuildStarted;

        void InvokeMovePerformed(Vector2 value);
        void InvokeRotatePerformed(float value);
        void InvokeMouse1PressStarted();
        void InvokeMouse1PressPerformed();
        void InvokeMouse1PressEnded();
        void InvokeMouse2PressStarted();
        void InvokeMouse2PressEnded();
        void InvokeMouse3PressStarted();
        void InvokeMouse3PressEnded();
        void InvokeMouse3ScrollPerformed(Vector2 value);
        void InvokeMouseMoveStarted(Vector2 value);
        void InvokeMousePositionPerformed(Vector2 value);
        void InvokeMousePositionPerformedWithMouse1(Vector2 value);
        void InvokeTimePausePressStarted();
        void InvokeTimeOneSpeedPressStarted();
        void InvokeTimeTwoSpeedPressStarted();
        void InvokeTimeThreeSpeedPressStarted();
        void InvokeTimeTogglePressStarted();
        void InvokeMenuPressStarted();
        void InvokeToggleBuildStarted();
    }
}