using System;
using System.IO;
using System.Reflection;
using com.Halcyon.API.Core.Modding;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Modding
{
    public static class ModsInitializer
    {
        internal static void CollectAndInitialiseAllMods()
        {
            GameManager.Instance.Logger.Log("Collecting and loading all mods.");
            
            string[] assemblies = CollectAssemblies();
            
            if (assemblies.Length > 0)
            {
                LoadAssemblies(assemblies);

                GameManager.Instance.Logger.Log("Completed collecting and loading all mods.");
            }
            else
            {
                GameManager.Instance.Logger.Log("No mods to load.");
            }
        }

        private static void LoadAssemblies(string[] assemblyPaths)
        {
            foreach (string path in assemblyPaths)
            {
                Assembly assembly = Assembly.LoadFrom(path);

                if (!IsCSharpAssembly(assembly)) continue;
                InitialiseAssembly(assembly);
            }
        }

        private static void InitialiseAssembly(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (!typeof(IMod).IsAssignableFrom(type)) continue;
                IMod modInitScript = (IMod)Activator.CreateInstance(type);

                try
                {
                    modInitScript.Initialise();
                    GameManager.Instance.Logger.Log($"Successfully initialised Mod {modInitScript.ModData.Name}");
                }
                catch (Exception e)
                {
                    GameManager.Instance.Logger.Log("Failed to initialise mod.", LogType.Error);
                    GameManager.Instance.Logger.LogException(e);
                }

                return;
            }
        }

        private static string[] CollectAssemblies()
        {
            string[] assemblies = Directory.GetFiles(Constants.ModsFolderPath, "*.dll", SearchOption.AllDirectories);
            GameManager.Instance.Logger.Log($"Collected {assemblies.Length} mod assemblies.");
            
            return assemblies;
        }

        private static bool IsCSharpAssembly(Assembly assembly)
        {
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                types = ex.Types;
            }
            
            return types != null && types.Length > 0;
        }
    }
}