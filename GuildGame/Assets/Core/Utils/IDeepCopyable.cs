namespace com.Halkyon.Utils
{
    public interface IDeepCopyable<T> : ICopyable<T> where T : IDeepCopyable<T>
    {
        T DeepCopy();
    }
}