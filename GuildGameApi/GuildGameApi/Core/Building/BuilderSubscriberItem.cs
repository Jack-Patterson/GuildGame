namespace com.Halcyon.API.Core.Building;

public abstract class BuilderSubscriberItem
{
    protected BuilderSubscriberItem()
    {
        GameManagerBase.Instance.Builder.SubscribeActionToGameStateEnabled(OnBuilderGameStateEnabled);
        GameManagerBase.Instance.Builder.SubscribeActionToGameStateEnabled(OnBuilderGameStateDisabled);
        
        GameManagerBase.Instance.Logger.Log("Subscribe item");
    }

    protected abstract void OnBuilderGameStateEnabled();
    protected abstract void OnBuilderGameStateDisabled();
}