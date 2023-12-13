using com.Halcyon.API.Core.Logger;
using com.Halcyon.API.Services.Serialization;
using UnityEngine;

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

    internal void OnMouseMove(Vector2 v2)
    {
        GameLogger.Log($"Mouse Moving {v2} from mod.");
    }

    internal void OnMove(Vector2 v2)
    {
        GameLogger.Log($"Moving to {v2} from mod.");
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