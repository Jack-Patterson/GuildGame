namespace com.Halcyon.API.Core.Modding;

public interface IMod
{
    public ModData ModData { get; set; }
    
    public void Initialise();
}