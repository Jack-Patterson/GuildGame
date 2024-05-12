using UnityEngine;

namespace com.Halkyon
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    _instance = gameManagerObject.AddComponent<GameManager>();
                    DontDestroyOnLoad(gameManagerObject);
                }

                return _instance;
            }
        }

        public void PrintHello()
        {
            print("Hello World!");
        }
    }
}