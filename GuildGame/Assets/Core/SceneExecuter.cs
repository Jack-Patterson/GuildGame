using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Halkyon
{
    public class SceneExecuter : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(LoadSceneAsync("Game"));
        }
        
        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            
            asyncOperation.allowSceneActivation = false;
            
            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                
                yield return null;
            }
        }
    }
}