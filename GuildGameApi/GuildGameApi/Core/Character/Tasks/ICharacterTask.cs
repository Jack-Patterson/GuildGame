namespace com.Halcyon.API.Core.Character.Tasks;

public interface ICharacterTask
{
    void InvokeOnStart();
    void InvokeOnPerform();
    void InvokeOnComplete();
}