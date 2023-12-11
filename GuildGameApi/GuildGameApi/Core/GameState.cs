namespace com.Halcyon.API.Core;

public static class GameState
{
    private static GameParameters? _gameParameters;

    public static GameParameters? GameParameters
    {
        get => _gameParameters;
        set => _gameParameters = value;
    }
}