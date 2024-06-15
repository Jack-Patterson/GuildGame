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
            
            yield return new WaitUntil(() => asyncOperation.progress >= 0.9f);

            asyncOperation.allowSceneActivation = true;
        }
    }
}