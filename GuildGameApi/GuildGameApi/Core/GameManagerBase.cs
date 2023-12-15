using com.Halcyon.API.Services.Input;
using com.Halcyon.API.Services.Logger;
using UnityEngine;

namespace com.Halcyon.API.Core;

public class GameManagerBase : MonoBehaviour
{
    private GameParameters _gameParameters = null!;
    private LoggerService _logger = null!;
    protected static GameManagerBase GManagerBase = null!;

    public static GameManagerBase Instance => GManagerBase;

    public LoggerService Logger
    {
        get => _logger;
        set => _logger = value;
    }

    public GameParameters GameParameters
    {
        get => _gameParameters;
        set => _gameParameters = value;
    }

    protected void Awake()
    {
        if (GManagerBase != null)
        {
            Destroy(gameObject);
        }
        else
        {
            GManagerBase = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}