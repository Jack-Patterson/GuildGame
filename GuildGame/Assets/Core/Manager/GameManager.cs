using Cinemachine;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.Manager
{
    public class GameManager : GameManagerBase
    {
        public new static GameManager Instance => GameManagerBase.Instance as GameManager;

        private CinemachineFreeLook _camera;

        public CinemachineFreeLook Camera
        {
            get => _camera;
            set => _camera = value;
        }

        private new void Awake()
        {
            base.Awake();
            InvokeReadyToAssignObjects();
            GameInitializer.InitialGameStartup();
        }
    }
}