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