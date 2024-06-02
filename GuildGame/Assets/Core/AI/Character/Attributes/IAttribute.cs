using com.Halkyon.Utils;

namespace com.Halkyon.AI.Character.Attributes
{
    public interface IAttribute<T> : ICopyable<T> where T : IAttribute<T>
    {
    }
}