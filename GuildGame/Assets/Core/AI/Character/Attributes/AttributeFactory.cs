using System;

namespace com.Halkyon.AI.Character.Attributes
{
    internal class AttributeFactory
    {
        public static T ConstructAttribute<T>(object[] arguments) where T : IAttribute<T>
        {
            if (arguments.Length < 1)
            {
                throw new ArgumentException("Arguments must contain at least one element.");
            }

            IAttribute<T> attribute = (IAttribute<T>)Activator
                .CreateInstance(typeof(T),
                    arguments);

            return (T)attribute;
        }
    }
}