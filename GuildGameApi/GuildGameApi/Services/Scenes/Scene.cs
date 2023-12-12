namespace com.Halcyon.API.Services.Scenes;

public struct Scene
{
    private int _sceneIndex;
    private string _name;

    public int SceneIndex
    {
        get => _sceneIndex;
        set => _sceneIndex = value;
    }
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Scene(string name, int sceneIndex)
    {
        _sceneIndex = sceneIndex;
        _name = name;
    }
}

public class SceneNotFoundException : Exception
{
    public SceneNotFoundException()
    {
    }

    public SceneNotFoundException(string? message) : base(message)
    {
    }
}