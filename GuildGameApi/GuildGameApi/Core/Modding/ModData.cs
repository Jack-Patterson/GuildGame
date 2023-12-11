namespace com.Halcyon.API.Core.Modding;

public class ModData
{
    private string _name;
    public string Name
    {
        get { return _name;}
        set { _name = value; }
    }

    public ModData(string name)
    {
        _name = name;
    }
}