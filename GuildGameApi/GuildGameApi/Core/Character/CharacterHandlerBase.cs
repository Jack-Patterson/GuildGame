namespace com.Halcyon.API.Core.Character;

public class CharacterHandlerBase : ExtendedMonoBehaviour
{
    protected override void OnStart()
    {
        GameManagerBase.Instance.CharacterHandlerBase = this;
    }
}