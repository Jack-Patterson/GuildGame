using com.Halcyon.API.Core;
using UnityEngine;

namespace GuildGameTestMod;

public class InputTest
{
    public void OnMouse1Click()
    {
        GameManagerBase.Instance.Logger.Log("Mouse 1 Clicked from mod.");
    }

    internal void OnMouseScroll(float f)
    {
        GameManagerBase.Instance.Logger.Log($"Mouse scrolling {f} from mod.");
    }

    internal void OnMouseMove(Vector2 v2)
    {
        GameManagerBase.Instance.Logger.Log($"Mouse Moving {v2} from mod.");
    }

    internal void OnMove(Vector2 v2)
    {
        GameManagerBase.Instance.Logger.Log($"Moving to {v2} from mod.");
    }

    internal void OnRotate(float f)
    {
        GameManagerBase.Instance.Logger.Log($"Rotating to {f} from mod.");
    }

    internal void OnPause()
    {
        GameManagerBase.Instance.Logger.Log("Pausing from mod.");
    }
}