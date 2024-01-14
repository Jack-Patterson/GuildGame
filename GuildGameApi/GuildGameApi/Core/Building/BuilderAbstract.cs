using com.Halcyon.API.Core.Building.BuilderItem;
using UnityEngine;

namespace com.Halcyon.API.Core.Building;

public abstract class BuilderAbstract : ExtendedMonoBehaviour
{
    [SerializeField] protected GameObject pointer = null!;
    [SerializeField] protected GameObject wallPrefab = null!;
    [SerializeField] protected GameObject wallPostPrefab = null!;
    [SerializeField] protected LayerMask placeRaycast;
    [SerializeField] protected LayerMask wallLayer;

    public event Action? BuilderGameStateEnabled;
    public event Action? BuilderGameStateDisabled;
    public event Action? BuilderInitialisationCompleted; 
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
    internal Action<RaycastHit>? OnMousePositionChanged;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value
    private List<IBuilderItem> _builderItems = new List<IBuilderItem>();
    protected Vector2 CurrentMousePosition = Vector2.zero;
    protected IFloorHandler _floorHandler = null!;

    public List<IBuilderItem> BuilderItems => _builderItems;
    public IFloorHandler FloorHandler => _floorHandler;

    public IBuilderItem AddBuilderItem
    {
        set => BuilderItems.Add(value);
    }

    private void OnDisable()
    {
        BuilderGameStateDisabled?.Invoke();
    }

    protected bool IsInBuildMode => GameManagerBase.Instance.GameParameters.GameState == GameState.Building;

    protected override void OnAwake()
    {
        GameManagerBase.ReadyToAssignObjects += () => GameManagerBase.Instance.Builder = this;;
    }

    protected void Start()
    {
        GameManagerBase.Instance.GameParameters.InputService.ToggleBuildStarted += ToggleBuilderGameState;
        
        BuilderGameStateEnabled += SubscribeBuilderMethods;
        BuilderGameStateDisabled += UnsubscribeBuilderMethods;
    }

    public GameObject InstantiateBuilderPrefab(GameObject builderPrefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(builderPrefab, position, rotation, transform);
        BuilderItems.Add(newObject.GetComponent<IBuilderItem>());

        return newObject;
    }

    public GameObject GetPrefabBasedOnType(BuilderItemType builderItemType)
    {
        switch (builderItemType)
        {
            case BuilderItemType.Wall:
                return wallPrefab;
            case BuilderItemType.WallPost:
                return wallPostPrefab;
        }

        return null!;
    }

    protected void ToggleBuilderGameState()
    {
        if (GameManagerBase.Instance.GameParameters.GameState == GameState.Building)
        {
            GameManagerBase.Instance.Logger.Log("Disabling building mode.");

            GameManagerBase.Instance.GameParameters.GameState = GameState.GameBase;
            BuilderGameStateDisabled?.Invoke();
        }
        else
        {
            GameManagerBase.Instance.Logger.Log("Enabling building mode.");

            GameManagerBase.Instance.GameParameters.GameState = GameState.Building;
            BuilderGameStateEnabled?.Invoke();
        }
    }
    
    protected void InvokeBuilderGameStateEnabled()
    {
        BuilderGameStateEnabled?.Invoke();
    }
    
    protected RaycastHit MousePositionToWorldPosition()
    {
        Ray ray = UnityEngine.Camera.main!.ScreenPointToRay(CurrentMousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, placeRaycast))
        {
            return hit;
        }

        return default;
    }

    private void InvokeOnMousePositionChanged(RaycastHit value)
    {
        OnMousePositionChanged?.Invoke(value);
    }
    
    protected void InvokeOnBuilderInitialisationComplete()
    {
        BuilderInitialisationCompleted?.Invoke();
    }

    protected abstract void UpdateCurrentMousePosition(Vector2 value);

    protected abstract void SubscribeBuilderMethods();

    protected abstract void UnsubscribeBuilderMethods();
}