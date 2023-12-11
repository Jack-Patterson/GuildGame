namespace com.Halcyon.API.Core.GameData;

public interface IGameData
{
    IGameDataSerializable ConvertToSerializableGameData(IGameData dataToConvert);
}