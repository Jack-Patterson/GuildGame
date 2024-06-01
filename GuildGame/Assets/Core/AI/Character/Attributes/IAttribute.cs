namespace com.Halkyon.AI.Character.Attributes
{
    public interface IAttribute<T> where T : IAttribute<T>
    {
        string Name { get; }
        
        void Register(T attribute);
        T DeepCopy();
    }
}