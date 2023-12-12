using com.Halcyon.API.Services;
using com.Halcyon.API.Services.Scenes;
using com.Halcyon.API.Services.Serialization;

namespace com.Halcyon.API.Core;

public class GameParameters
{
    private IDataService _jsonDataService;
    private ISceneService _sceneService;
    private GameState _gameState;

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
    
    public GameState GameState
    {
        get => _gameState;
        set => _gameState = value;
    }

    public GameParameters(IDataService jsonDataService, ISceneService sceneService, GameState gameState)
    {
        _jsonDataService = jsonDataService;
        _sceneService = sceneService;
        _gameState = gameState;
    }
}