using System.IO;
using UnityEngine;

namespace com.Halcyon.Core.Utils
{
    public class Constants : MonoBehaviour
    {
        public static readonly string ModsFolderPath =
            Path.Combine(Application.persistentDataPath, "Mods").Replace("\\", "/");

        public static readonly string LogsFolderPath =
            Path.Combine(Application.persistentDataPath, "Logs").Replace("\\", "/");

        public static readonly string SavesFolderPath =
            Path.Combine(Application.persistentDataPath, "Saves").Replace("\\", "/");

        public static readonly string DiscordInviteLink = "https://discord.gg/FnKBMfRqRb";

        public static class BuilderConstants
        {
            public const float DefaultGridSize = 10f;
            public const float MaxGridSize = 50f;
            public const float MaxUnityGridSize = 10f;
            public const float FloorHeight = 10f;
            public const int WallCheckRadius = 1;
            public const int PostCheckRadius = 1;
        }

        public static class CharacterConstants
        {
            public static class CharacterNeedsConstants
            {
                 public const float MaxValue = 100;
                 public const float MinValue = -100;
                 public const float BaseNeedDecay = 0.1f;
                 public const float BaseValue = 100;
                 public static float NeedsDecayWaitDuration = 2f;
            }
            
            public static class CharacterStatsConstants
            {
                public const float MaxValue = 100;
                public const float MinValue = 0;
                public const float BaseValue = 0;
            }
        }
    }
}