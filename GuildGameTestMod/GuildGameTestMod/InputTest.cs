using com.Halcyon.API.Core.Logger;
using com.Halcyon.API.Services.Serialization;

namespace GuildGameTestMod;

public class InputTest
{
    public void OnMouse1Click()
    {
        GameLogger.Log("Mouse 1 Clicked from mod.");
    }

    internal void OnMouseScroll(float f)
    {
        GameLogger.Log($"Mouse scrolling {f} from mod.");
    }

    internal void OnMouseMove(SerializableVector2 v2)
    {
        GameLogger.Log($"Mouse Moving {v2.GetUnityVector()} from mod.");
    }

    internal void OnMove(SerializableVector2 v2)
    {
        GameLogger.Log($"Moving to {v2.GetUnityVector()} from mod.");
    }

    internal void OnRotate(float f)
    {
        GameLogger.Log($"Rotating to {f} from mod.");
    }

    internal void OnPause()
    {
        GameLogger.Log("Pausing from mod.");
    }
}