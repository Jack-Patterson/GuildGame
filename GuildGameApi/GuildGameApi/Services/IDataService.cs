namespace com.Halcyon.API.Services;

public interface IDataService
{
    bool SaveData<T>(T objectToSerialize, string saveLocation, bool encrypted = false);
    T LoadData<T>(string saveLocation, bool encrypted = false);
}