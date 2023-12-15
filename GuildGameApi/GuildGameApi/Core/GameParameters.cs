using com.Halcyon.API.Services.Input;
using com.Halcyon.API.Services.Scenes;
using com.Halcyon.API.Services.Serialization;

namespace com.Halcyon.API.Core;

public class GameParameters
{
    private ISerializationService _jsonSerializationService;
    private ISceneService _sceneService;
    private IInputService _inputService;
    private GameState _gameState;

    public ISceneService SceneService
    {
        get => _sceneService;
        set => _sceneService = value;
    }

    public ISerializationService JsonSerializationService
    {
        get => _jsonSerializationService;
        set => _jsonSerializationService = value;
    }
    
    public IInputService InputService
    {
        get => _inputService;
        set => _inputService = value;
    }

    public GameState GameState
    {
        get => _gameState;
        set => _gameState = value;
    }

    public GameParameters(ISerializationService jsonSerializationService, ISceneService sceneService,  IInputService inputService, GameState gameState)
    {
        _jsonSerializationService = jsonSerializationService;
        _sceneService = sceneService;
        _inputService = inputService;
        _gameState = gameState;
    }
}