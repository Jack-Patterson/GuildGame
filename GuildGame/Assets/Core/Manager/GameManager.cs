using Cinemachine;
using com.Halcyon.API.Core;

namespace com.Halcyon.Core.Manager
{
    public class GameManager : GameManagerBase
    {
        public new static GameManager Instance => GameManagerBase.Instance as GameManager;

        private CinemachineFreeLook _virtualCamera;

        public CinemachineFreeLook VirtualCamera
        {
            get => _virtualCamera;
            set => _virtualCamera = value;
        }

        private new void Awake()
        {
            base.Awake();
            GameInitializer.InitialGameStartup();
        }

        private void Update()
        {
            // if (Input.anyKey)
            // {
            //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            //     int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            //     SceneManager.LoadScene(nextSceneIndex);
            // }

            // print(_testNum);
        }
    }
}