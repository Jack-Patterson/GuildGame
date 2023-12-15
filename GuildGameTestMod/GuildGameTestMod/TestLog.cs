using com.Halcyon.API.Core;
using com.Halcyon.API.Services.Logger;

namespace GuildGameTestMod;

public class TestLog
{
    internal static void TestLogMsg(LoggerParameters loggerParameters)
    {
        GameManagerBase.Instance.Logger.Log(loggerParameters);
    }
}