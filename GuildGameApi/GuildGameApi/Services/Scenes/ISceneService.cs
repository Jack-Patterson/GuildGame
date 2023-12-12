namespace com.Halcyon.API.Services.Scenes;

public interface ISceneService
{
    List<Scene> Scenes { get; }
    void AddScene(Scene scene);
    Scene GetScene(int sceneIndex);
    Scene GetScene(string name);
    void ChangeToScene(Scene scene);
    void ChangeToScene(int sceneIndex);
    void ChangeToScene(string name);
    void ReloadScene();
}