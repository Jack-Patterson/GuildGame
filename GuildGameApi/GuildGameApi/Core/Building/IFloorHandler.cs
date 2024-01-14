namespace com.Halcyon.API.Core.Building;

public interface IFloorHandler
{
    int CurrentFloor { get; set;  }
    
    event Action<int>? OnFloorChanged;
    
    void InvokeFloorChanged(int value);
}