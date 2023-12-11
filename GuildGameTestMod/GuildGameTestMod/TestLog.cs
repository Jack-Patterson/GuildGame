using com.Halcyon.API.Core.Logger;

namespace GuildGameTestMod;

public class TestLog
{
    internal static void TestLogMsg(GameLoggerParameters loggerParameters)
    {
        GameLogger.Log(loggerParameters);
    }
}