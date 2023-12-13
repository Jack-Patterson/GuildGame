using UnityEngine;

namespace com.Halcyon.API.Services.Input;

public abstract class InputServiceAbstract : MonoBehaviour, IInputService
{
    public event Action<Vector2>? MovePerformed;
    public event Action<float>? RotatePerformed;
    
    public event Action? Mouse1PressStarted;
    public event Action? Mouse1PressEnded;
    public event Action? Mouse2PressStarted;
    public event Action? Mouse2PressEnded;
    public event Action? Mouse3PressStarted;
    public event Action? Mouse3PressEnded;
    public event Action<float>? Mouse3ScrollPerformed;
    public event Action<Vector2>? MouseMoveStarted;
    
    public event Action? MenuPressStarted;
    
    public event Action? TimePausePressStarted;
    public event Action? TimeOneSpeedPressStarted;
    public event Action? TimeTwoSpeedPressStarted;
    public event Action? TimeThreeSpeedPressStarted;
    public event Action? TimeTogglePressStarted;

    protected void InvokeMovePerformed(Vector2 value)
    {
        MovePerformed?.Invoke(value);
    }
    
    protected void InvokeRotatePerformed(float value)
    {
        RotatePerformed?.Invoke(value);
    }
    
    protected void InvokeMouse1PressStarted()
    {
        Mouse1PressStarted?.Invoke();
    }
    
    protected void InvokeMouse1PressEnded()
    {
        Mouse1PressEnded?.Invoke();
    }
    
    protected void InvokeMouse2PressStarted()
    {
        Mouse2PressStarted?.Invoke();
    }
    
    protected void InvokeMouse2PressEnded()
    {
        Mouse2PressEnded?.Invoke();
    }
    
    protected void InvokeMouse3PressStarted()
    {
        Mouse3PressStarted?.Invoke();
    }
    
    protected void InvokeMouse3PressEnded()
    {
        Mouse3PressEnded?.Invoke();
    }
    
    protected void InvokeMouse3ScrollPerformed(Vector2 value)
    {
        Mouse3ScrollPerformed?.Invoke(value.y);
    }
    
    protected void InvokeMouseMoveStarted(Vector2 value)
    {
        MouseMoveStarted?.Invoke(value);
    }
    
    protected void InvokeMenuPressStarted()
    {
        MenuPressStarted?.Invoke();
    }
    
    protected void InvokeTimePausePressStarted()
    {
        TimePausePressStarted?.Invoke();
    }
    
    protected void InvokeTimeOneSpeedPressStarted()
    {
        TimeOneSpeedPressStarted?.Invoke();
    }
    
    protected void InvokeTimeTwoSpeedPressStarted()
    {
        TimeTwoSpeedPressStarted?.Invoke();
    }
    
    protected void InvokeTimeThreeSpeedPressStarted()
    {
        TimeThreeSpeedPressStarted?.Invoke();
    }
    
    protected void InvokeTimeTogglePressStarted()
    {
        TimeTogglePressStarted?.Invoke();
    }
}