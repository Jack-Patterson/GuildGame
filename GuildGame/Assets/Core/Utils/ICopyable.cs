namespace com.Halkyon.Utils
{
    public interface ICopyable<T> where T : ICopyable<T>
    {
        T Copy();
    }
}