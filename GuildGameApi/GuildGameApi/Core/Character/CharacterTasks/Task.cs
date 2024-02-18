using UnityEngine;

namespace com.Halcyon.API.Core.Character.CharacterTasks;

public abstract class Task : LoggerUtil
{
    protected Character Character;
    
    protected Task(Character character)
    {
        Character = character;
    }
    
    public abstract void Perform();
}

public abstract class Task<T> : Task
{
    protected Task(Character character) : base(character)
    {
    }

    public abstract void Perform(T data);
}

public class MoveTask : Task<Vector3>
{
    public MoveTask(Character character) : base(character)
    {
    }

    public override void Perform()
    {
        Perform(Vector3.zero);
    }

    public override void Perform(Vector3 data)
    {
        Character.SetTarget(data);
    }
}