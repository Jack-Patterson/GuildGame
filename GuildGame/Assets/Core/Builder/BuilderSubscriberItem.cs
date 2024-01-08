using com.Halcyon.Core.Manager;

namespace com.Halcyon.Core.Builder
{
    public abstract class BuilderSubscriberItem
    {
        protected BuilderSubscriberItem()
        {
            GameManager.Instance.Logger.Log(GameManager.Instance.Builder);
            GameInitializer.GameInitializationComplete += SubscribeGridBuildMethods;

            GameManager.Instance.Logger.Log("Subscribe item");
        }

        public abstract void SubscribeGridBuildMethods();
    }
}