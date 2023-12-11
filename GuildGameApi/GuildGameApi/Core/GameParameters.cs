using com.Halcyon.API.Services;
using com.Halcyon.API.Services.Serialization;

namespace com.Halcyon.API.Core;

public class GameParameters
{
    private IDataService _jsonDataService;

    public IDataService JsonDataService
    {
        get => _jsonDataService;
        set => _jsonDataService = value;
    }

    public GameParameters(IDataService jsonDataService)
    {
        _jsonDataService = jsonDataService;
    }
}