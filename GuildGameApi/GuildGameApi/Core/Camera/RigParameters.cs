namespace com.Halcyon.API.Core.Camera;

public class RigParameters
{
    private float _height = 0f;
    private float _radius = 0f;

    public float Height
    {
        get => _height;
        set => _height = value;
    }

    public float Radius
    {
        get => _radius;
        set => _radius = value;
    }

    public RigParameters(float height, float radius)
    {
        _height = height;
        _radius = radius;
    }
}