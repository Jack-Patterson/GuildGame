using UnityEngine;

namespace com.Halcyon.API.Core.Logger;

public class GameLoggerParameters
{
    private string _message;
    private LogType _logType;
    private Exception? _exception;

    public string Message
    {
        get => _message;
        set => _message = value;
    }

    public LogType LogType
    {
        get => _logType;
        set => _logType = value;
    }

    public Exception? Exception
    {
        get => _exception;
        set => _exception = value;
    }

    public GameLoggerParameters(string message, LogType logType = LogType.Log, Exception? exception = null)
    {
        _message = message;
        _logType = logType;
        _exception = exception;
    }
}