namespace com.Halcyon.API.Modding;

public interface IMod
{
    public ModData ModData { get; set; }
    
    public void Initialise();
}