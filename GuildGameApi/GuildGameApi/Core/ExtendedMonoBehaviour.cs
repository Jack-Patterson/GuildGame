using UnityEngine;

namespace com.Halcyon.API.Core;

public abstract class ExtendedMonoBehaviour : LoggerUtilMonoBehaviour
{
    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }
    
    public Quaternion Rotation
    {
        get => transform.rotation;
        set => transform.rotation = value;
    }

    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }
    
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }

    private void OnEnable()
    {
        OnOnEnable();
    }

    private void OnDisable()
    {
        OnOnDisable();
    }
    
    private void OnDestroy()
    {
        OnOnDestroy();
    }
    
    protected virtual void OnStart(){}
    protected virtual void OnUpdate(){}
    protected virtual void OnFixedUpdate(){}
    protected virtual void OnAwake(){}
    protected virtual void OnOnEnable(){}
    protected virtual void OnOnDisable(){}
    protected virtual void OnOnDestroy(){}
    
    protected void Singleton<T>(ref T instance, bool dontDestroyOnLoad = false) where T : ExtendedMonoBehaviour
    {
        if (instance == null)
        {
            instance = (this as T)!;
            
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}