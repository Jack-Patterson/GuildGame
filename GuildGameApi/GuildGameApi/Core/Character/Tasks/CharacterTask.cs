using UnityEngine;

namespace com.Halcyon.API.Core.Character.Tasks;

public abstract class CharacterTask<T> : ICharacterTask
{
    private ICharacterTask _nextTask;
    public event Action OnStart = null!;
    public event Action<T?> OnPerform = null!;
    public event Action<ICharacterTask> OnComplete = null!;
    
    protected CharacterTask(ICharacterTask nextTask)
    {
        _nextTask = nextTask;
    }

    protected abstract void Start();
    protected abstract void Perform(T? data);
    protected abstract void Complete(ICharacterTask characterTask);
    
    public void InvokeOnStart()
    {
        OnStart?.Invoke();
    }
    
    public void InvokeOnPerform()
    {
        OnPerform?.Invoke(default);
    }
    
    public void InvokeOnPerform(T? data)
    {
        OnPerform?.Invoke(data);
    }
    
    public void InvokeOnComplete()
    {
        OnComplete?.Invoke(_nextTask);
    }
}