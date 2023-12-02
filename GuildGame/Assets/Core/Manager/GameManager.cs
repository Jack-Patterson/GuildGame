using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Halcyon.Core.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private int _testNum = 0;
        
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
            
            if (!Directory.Exists(Constants.ModsFolderPath))
            {
                CreateFolder(Constants.ModsFolderPath);
            }
            
            if (!Directory.Exists(Constants.LogsFolderPath))
            {
                CreateFolder(Constants.LogsFolderPath);
            }
            
            GameLogger.Init();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
                SceneManager.LoadScene(nextSceneIndex);
            }
            
            // print(_testNum);
        }

        private void CreateFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error creating folder {path}: {e.Message}");
            }
        }
    }
}