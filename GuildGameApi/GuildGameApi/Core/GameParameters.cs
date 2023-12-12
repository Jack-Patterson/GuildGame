using com.Halcyon.API.Services;
using com.Halcyon.API.Services.Scenes;
using com.Halcyon.API.Services.Serialization;

namespace com.Halcyon.API.Core;

public class GameParameters
{
    private IDataService _jsonDataService;
    private ISceneService _sceneService;

    public ISceneService SceneService
    {
        get => _sceneService;
        set => _sceneService = value;
    }

    public IDataService JsonDataService
    {
        get => _jsonDataService;
        set => _jsonDataService = value;
    }

    public GameParameters(IDataService jsonDataService, ISceneService sceneService)
    {
        _jsonDataService = jsonDataService;
        _sceneService = sceneService;
    }
}