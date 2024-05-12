using com.Halcyon.API.Core;
using com.Halcyon.Core.Manager;

namespace com.Halkyon.Core.Utils
{
    public abstract class MonoBehaviourExtended : LoggerUtilMonoBehaviour
    {
        protected GameManager GameManager => GameManager.Instance;
    }
}