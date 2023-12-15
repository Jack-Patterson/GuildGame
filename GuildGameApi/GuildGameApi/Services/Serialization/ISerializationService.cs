namespace com.Halcyon.API.Services.Serialization;

public interface ISerializationService
{
    bool SaveData<T>(T objectToSerialize, string relativeSaveLocation, bool encrypted = false);
    T LoadData<T>(string relativeSaveLocation, bool encrypted = false);
}