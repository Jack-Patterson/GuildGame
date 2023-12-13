using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Modding;
using com.Halcyon.API.Services.Input;
using UnityEngine;

namespace GuildGameTestMod;

public class IntialiseClass : IMod
{
    private ModData _modData = null!;

    public ModData ModData
    {
        get => _modData;
        set => _modData = value;
    }

    public void Initialise()
    {
        // TestLog.TestLogMsg(new GameLoggerParameters("testmsg"));
        // TestLog.TestLogMsg(new GameLoggerParameters("testmsg", LogType.Warning));
        // TestLog.TestLogMsg(new GameLoggerParameters("testmsg", LogType.Error));
        // TestLog.TestLogMsg(new GameLoggerParameters("testmsg", LogType.Exception, new IndexOutOfRangeException("testmsg")));

        InputTest inputTest = new InputTest();

        GameManagerBase.Instance.InputHandlerInstance = new InputHandlerInstance();
        
        Debug.Log(GameManagerBase.Instance);
        Debug.Log(GameManagerBase.Instance.GameParameters);
        Debug.Log(GameManagerBase.Instance.GameParameters.InputService);
        GameManagerBase.Instance.GameParameters.InputService.Mouse1PressStarted += inputTest.OnMouse1Click;
        GameManagerBase.Instance.GameParameters.InputService.MouseMoveStarted += inputTest.OnMouseMove;
        GameManagerBase.Instance.GameParameters.InputService.Mouse3ScrollPerformed += inputTest.OnMouseScroll;
        GameManagerBase.Instance.GameParameters.InputService.MovePerformed += inputTest.OnMove;
        GameManagerBase.Instance.GameParameters.InputService.RotatePerformed += inputTest.OnRotate;
        GameManagerBase.Instance.GameParameters.InputService.TimePausePressStarted += inputTest.OnPause;

        ModData = new ModData("TestName");
    }
}