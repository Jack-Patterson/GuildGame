using com.Halcyon.API.Core.Building;
using com.Halcyon.Core.Manager;

namespace com.Halcyon.Core.Builder
{
    public abstract class BuilderSubscriberItem
    {
        protected BuilderSubscriberItem()
        {
            BuilderAbstract builder = GameManager.Instance.Builder;
            
            builder.BuilderGameStateEnabled += SubscribeGridBuildMethods;
            builder.BuilderGameStateDisabled += UnsubscribeGridBuildMethods;
        }

        public abstract void SubscribeGridBuildMethods();
        public abstract void UnsubscribeGridBuildMethods();
    }
}