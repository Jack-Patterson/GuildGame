using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Manager
{
    public class GameManager : GameManagerBase
    {
        public new static GameManager Instance => GameManagerBase.Instance as GameManager;
        
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