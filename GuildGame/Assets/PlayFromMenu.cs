#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace com.Halkyon
{
    [InitializeOnLoad]
    public static class PlayFromMenu
    {
        static PlayFromMenu()
        {
            EditorApplication.playModeStateChanged += LoadBootstrapSceneOnPlay;
        }

        private static void LoadBootstrapSceneOnPlay(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                string bootstrapScenePath = "Assets/Scenes/Menu.unity";

                if (!EditorSceneManager.GetActiveScene().path.Equals(bootstrapScenePath))
                {
                    SceneManager.LoadScene(bootstrapScenePath);
                }
            }
        }
    }
}
#endif