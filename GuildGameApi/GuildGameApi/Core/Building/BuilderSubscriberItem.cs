namespace com.Halcyon.API.Core.Building;

public abstract class BuilderSubscriberItem
{
    protected BuilderSubscriberItem()
    {
        GameManagerBase.Instance.Logger.Log(GameManagerBase.Instance.Builder);
        GameManagerBase.Instance.Builder.BuilderGameStateEnabled += OnBuilderGameStateEnabled;
        GameManagerBase.Instance.Builder.BuilderGameStateEnabled += OnBuilderGameStateDisabled;
        
        GameManagerBase.Instance.Logger.Log("Subscribe item");
    }

    protected abstract void OnBuilderGameStateEnabled();
    protected abstract void OnBuilderGameStateDisabled();
}