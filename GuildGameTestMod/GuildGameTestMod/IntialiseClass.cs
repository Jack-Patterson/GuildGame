using com.Halcyon.API.Manager;
using com.Halcyon.API.Modding;
using UnityEngine;

namespace GuildGameTestMod;

public class IntialiseClass: IMod
{
    private ModData _modData;

    public ModData ModData
    {
        get => _modData;
        set => _modData = value;
    }

    public void Initialise()
    {
        TestLog.TestLogMsg(new GameLoggerParameters("testmsg"));
        TestLog.TestLogMsg(new GameLoggerParameters("testmsg", LogType.Warning));
        TestLog.TestLogMsg(new GameLoggerParameters("testmsg", LogType.Error));
        TestLog.TestLogMsg(new GameLoggerParameters("testmsg", LogType.Exception, new IndexOutOfRangeException("testmsg")));

        ModData = new ModData("TestName");
    }
}