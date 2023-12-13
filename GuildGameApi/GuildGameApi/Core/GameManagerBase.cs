using com.Halcyon.API.Services.Input;
using UnityEngine;

namespace com.Halcyon.API.Core;

public class GameManagerBase : MonoBehaviour
{
    private GameParameters _gameParameters = null!;
    protected static GameManagerBase GManagerBase = null!;
    
    public static GameManagerBase Instance => GManagerBase;

    public InputHandlerInstance InputHandlerInstance;
    // protected static GameManagerBase BaseInstance = null!;
        
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

    public GameParameters GameParameters
    {
        get => _gameParameters;
        set => _gameParameters = value;
    }
}