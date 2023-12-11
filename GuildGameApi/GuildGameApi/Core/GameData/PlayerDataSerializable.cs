namespace com.Halcyon.API.Core.GameData;

public class PlayerDataSerializable: IGameDataSerializable
{
    private long money;

    public long Money
    {
        get => money;
        set => money = value;
    }

    public PlayerDataSerializable(long money)
    {
        Money = money;
    }


    public IGameData ConvertToGameData(IGameDataSerializable dataToConvert)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return Money.ToString("0000");
    }
}