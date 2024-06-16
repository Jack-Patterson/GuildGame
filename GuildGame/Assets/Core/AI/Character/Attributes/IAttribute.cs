using com.Halkyon.Utils;

namespace com.Halkyon.AI.Character.Attributes
{
    public interface IAttribute<T> : IAttribute, IDeepCopyable<T> where T : IAttribute<T>
    {
        string Name { get; }

        void Reset();
        string ToString();
    }
    
    public interface IAttribute{}
}