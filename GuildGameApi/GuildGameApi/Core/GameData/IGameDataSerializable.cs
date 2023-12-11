namespace com.Halcyon.API.Core.GameData;

public interface IGameDataSerializable
{
    IGameData ConvertToGameData(IGameDataSerializable dataToConvert);
}