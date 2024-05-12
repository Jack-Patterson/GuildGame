using System.IO;
using UnityEngine;

namespace com.Halkyon.Utils
{
    public class Constants
    {
        public static readonly string ModsFolderPath =
            Path.Combine(Application.persistentDataPath, "Mods").Replace("\\", "/");

        public static readonly string LogsFolderPath =
            Path.Combine(Application.persistentDataPath, "Logs").Replace("\\", "/");

        public static readonly string SavesFolderPath =
            Path.Combine(Application.persistentDataPath, "Saves").Replace("\\", "/");

        public static readonly string DiscordInviteLink = "https://discord.gg/FnKBMfRqRb";
    }
}