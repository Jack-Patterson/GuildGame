using System.IO;
using UnityEngine;

namespace com.Halcyon.Core
{
    public static class Constants
    {
        public static readonly string ModsFolderPath = Path.Combine(Application.persistentDataPath, "Mods").Replace("\\", "/");
        public static readonly string LogsFolderPath = Path.Combine(Application.persistentDataPath, "Logs").Replace("\\", "/");
        public static readonly string SavesFolderPath = Path.Combine(Application.persistentDataPath, "Saves").Replace("\\", "/");
        public static readonly string DiscordInviteLink = "https://discord.gg/FnKBMfRqRb";
        public static readonly int DefaultGridSize = 10;
    }
}