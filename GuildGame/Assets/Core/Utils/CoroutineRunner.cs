using System.Collections;
using UnityEngine;

namespace com.Halkyon.Utils
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}