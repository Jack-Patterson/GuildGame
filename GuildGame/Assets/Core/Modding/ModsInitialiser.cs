using System;
using System.IO;
using System.Reflection;
using com.Halcyon.API.Modding;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Modding
{
    public static class ModsInitialiser
    {
        internal static void CollectAndInitialiseAllMods()
        {
            GameLogger.Log("Collecting and loading all mods.");
            
            string[] assemblies = CollectAssemblies();
            
            if (assemblies.Length > 0)
            {
                LoadAssemblies(assemblies);

                GameLogger.Log("Completed collecting and loading all mods.");
            }
            else
            {
                GameLogger.Log("No mods to load.");
            }
        }

        private static void LoadAssemblies(string[] assemblyPaths)
        {
            foreach (string path in assemblyPaths)
            {
                Assembly assembly = Assembly.LoadFrom(path);

                if (IsCSharpAssembly(assembly))
                    continue;

                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IMod).IsAssignableFrom(type))
                    {
                        IMod modInitScript = (IMod)Activator.CreateInstance(type);

                        try
                        {
                            modInitScript.Initialise();
                            GameLogger.Log($"Successfully initialised Mod {modInitScript.ModData.Name}");
                        }
                        catch (Exception e)
                        {
                            GameLogger.Log("Failed to initialise mod.", LogType.Error);
                            GameLogger.LogException(e);
                        }

                        return;
                    }
                }
            }
        }

        private static string[] CollectAssemblies()
        {
            string[] assemblies = Directory.GetFiles(Constants.ModsFolderPath, "*.dll", SearchOption.AllDirectories);
            GameLogger.Log($"Collected {assemblies.Length} mod assemblies.");
            
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