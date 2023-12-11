using UnityEngine;

namespace com.Halcyon.Core.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            DontDestroyOnLoad(gameObject);
            
            
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