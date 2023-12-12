using UnityEngine;

namespace com.Halcyon.API.Core;

public abstract class GameManagerBase : MonoBehaviour
{
    private GameParameters _gameParameters;

    public GameParameters GameParameters
    {
        get => _gameParameters;
        set => _gameParameters = value;
    }
}