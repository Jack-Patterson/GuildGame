using com.Halcyon.API.Manager;

namespace GuildGameTestMod;

public class TestLog
{
    internal static void TestLogMsg(GameLoggerParameters loggerParameters)
    {
        GameLogger.Log(loggerParameters);
    }
}