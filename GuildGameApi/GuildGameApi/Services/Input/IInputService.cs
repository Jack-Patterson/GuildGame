using UnityEngine;

namespace com.Halcyon.API.Services.Input;

internal interface IInputService
{
    event Action<Vector2> MovePerformed;
    event Action<float> RotatePerformed;
    
    event Action Mouse1PressStarted;
    event Action Mouse1PressEnded;
    event Action Mouse2PressStarted;
    event Action Mouse2PressEnded;
    event Action Mouse3PressStarted;
    event Action Mouse3PressEnded;
    event Action<float> Mouse3ScrollPerformed;
    event Action<Vector2> MouseMoveStarted;

    event Action MenuPressStarted;
    
    event Action TimePausePressStarted;
    event Action TimeOneSpeedPressStarted;
    event Action TimeTwoSpeedPressStarted;
    event Action TimeThreeSpeedPressStarted;
    event Action TimeTogglePressStarted;
}