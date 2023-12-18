using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.DataHolder;
using com.Halcyon.API.Services.Logger;
using UnityEngine;

namespace com.Halcyon.API.Core;

public class GameManagerBase : MonoBehaviour
{
    private static GameManagerBase _gManagerBase = null!;
    
    private GameParameters _gameParameters = null!;
    private LoggerService _logger = null!;
    private BuilderAbstract _builder = null!;
    private IDataHolderService _dataHolder = null!;
    private ICameraParameters _cameraParameters = null!;
    // private CinemachineVirtualCamera _cinemachineVirtualCamera;

    public static GameManagerBase Instance => _gManagerBase;

    public LoggerService Logger
    {
        get => _logger;
        set => _logger = value;
    }
    
    public BuilderAbstract Builder
    {
        get => _builder;
        set => _builder = value;
    }
    
    public IDataHolderService DataHolder
    {
        get => _dataHolder;
        set => _dataHolder = value;
    }
    
    public ICameraParameters CameraParameters
    {
        get => _cameraParameters;
        set => _cameraParameters = value;
    }

    public GameParameters GameParameters
    {
        get => _gameParameters;
        set => _gameParameters = value;
    }

    protected void Awake()
    {
        if (_gManagerBase != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _gManagerBase = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}