using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.Halcyon.Core.Utils
{
    public static class GameUtils
    {
        public static IEnumerable<Type> GetAllObjectsOfType<T>()
        {
            List<Type> types = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && type.Namespace != null && type.Namespace.StartsWith("com.Halcyon.Core") &&
                        typeof(T).IsAssignableFrom(type))
                    {
                        types.Add(type);
                    }
                }
            }

            return types;
        }
        
        public static IEnumerable<Type> GetAllObjectsOfType<T>(string namespaceName)
        {
            List<Type> types = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && type.Namespace != null && type.Namespace.StartsWith(namespaceName) &&
                        typeof(T).IsAssignableFrom(type))
                    {
                        types.Add(type);
                    }
                }
            }

            return types;
        }
    }
}