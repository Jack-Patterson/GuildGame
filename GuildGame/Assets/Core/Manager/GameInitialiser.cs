using System;
using com.Halcyon.Core.Modding;

namespace com.Halcyon.Core.Manager
{
    public static class GameInitialiser
    {
        internal static void InitialGameStartup()
        {
            GameLogger.Log("Beginning initial game startup.");
            
            ModsInitialiser.CollectAndInitialiseAllMods();
        }

        private static void HandleCommandLineArguments()
        {
            string[] startupArguments = Environment.GetCommandLineArgs();

            foreach (string argument in startupArguments)
            {
                if (argument.Equals("-developerMode"))
                {
                    
                }
            }
        }
    }
}