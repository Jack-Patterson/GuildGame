namespace com.Halcyon.API.Core.Character.CharacterTasks;

public abstract class TaskHandler : ExtendedMonoBehaviour
{
    protected List<Task> tasks = null!;
    protected Character Character = null!;
    public List<Task> Tasks => tasks;

    private void Awake()
    {
        tasks = new List<Task>();
        Character = GetComponent<Character>();
    }

    public abstract void AddTask(Task task);

    public abstract void RemoveTask(Task task);

    public abstract void SetTasks(List<Task> tasks);
}