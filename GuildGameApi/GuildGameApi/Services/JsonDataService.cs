using System.Runtime.Serialization;

namespace com.Halcyon.API.Services;

public class JsonDataService : IDataService
{
    private static IDataService? _jsonDataService;

    public JsonDataService()
    {
    }

    public JsonDataService(IDataService jsonDataService)
    {
        _jsonDataService = jsonDataService;
    }

    public bool SaveData<T>(T objectToSerialize, string saveLocation, bool encrypted = false)
    {
        if (_jsonDataService == null)
        {
            throw new SerializationException(
                "Failed to serialize object. Data service has not been initialized.");
        }

        return _jsonDataService.SaveData(objectToSerialize, saveLocation, encrypted);
    }

    public T LoadData<T>(string saveLocation, bool encrypted = false)
    {
        if (_jsonDataService == null)
        {
            throw new SerializationException(
                "Failed to deserialize object. Data service has not been initialized.");
        }

        return _jsonDataService.LoadData<T>(saveLocation, encrypted);
    }
}