namespace com.Halcyon.API.Core.Character;

public class CharacterManager : ExtendedMonoBehaviour
{
    protected override void OnStart()
    {
        GameManagerBase.Instance.CharacterManager = this;
    }
}