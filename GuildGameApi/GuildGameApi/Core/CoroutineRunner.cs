using System.Collections;
using UnityEngine;

namespace com.Halcyon.API.Core;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner _instance = null!;
    private readonly Dictionary<IEnumerator, Coroutine> _runningCoroutines = new();

    public static CoroutineRunner Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CoroutineRunner");
                _instance = obj.AddComponent<CoroutineRunner>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public Coroutine RunCoroutine(IEnumerator coroutine)
    {
        Coroutine runningCoroutine = StartCoroutine(coroutine);
        _runningCoroutines[coroutine] = runningCoroutine;
        return runningCoroutine;
    }

    public void StopRunningCoroutine(IEnumerator coroutine)
    {
        if (_runningCoroutines.TryGetValue(coroutine, out Coroutine runningCoroutine))
        {
            StopCoroutine(runningCoroutine);
            _runningCoroutines.Remove(coroutine);
        }
    }
}