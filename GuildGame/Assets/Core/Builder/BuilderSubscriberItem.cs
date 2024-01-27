using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.Core.Manager;

namespace com.Halcyon.Core.Builder
{
    public abstract class BuilderSubscriberItem : LoggerUtil
    {
        protected BuilderSubscriberItem()
        {
            BuilderAbstract builder = GameManager.Instance.Builder;

            builder.BuilderGameStateEnabled += SubscribeGridBuildMethods;
            builder.BuilderGameStateDisabled += UnsubscribeGridBuildMethods;
        }

        protected internal abstract void SubscribeGridBuildMethods();
        protected internal abstract void UnsubscribeGridBuildMethods();
    }
}