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
    public static event Action? BuilderInitialisationCompleted;
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
    internal Action<RaycastHit>? OnMousePositionChanged;
#pragma warning restore CS0649 // Field is never assigned to, and will always have its default value
    
    protected BuilderItemsHandler<IWallBuilderItem> _wallBuilderItems = null!;
    protected BuilderItemsHandler<IFloorBuilderItem> _floorBuilderItems = null!;
    protected Vector2 CurrentMousePosition = Vector2.zero;
    protected IFloorHandler _floorHandler = null!;

    public BuilderItemsHandler<IWallBuilderItem> WallBuilderItems => _wallBuilderItems;
    public BuilderItemsHandler<IFloorBuilderItem> FloorBuilderItems => _floorBuilderItems;
    public IFloorHandler FloorHandler => _floorHandler;

    public IWallBuilderItem AddBuilderItem
    {
        set => WallBuilderItems.Add(FloorHandler.CurrentFloor, value);
    }

    private void OnDisable()
    {
        BuilderGameStateDisabled?.Invoke();
    }

    protected bool IsInBuildMode => GameManagerBase.Instance.GameParameters.GameState == GameState.Building;

    protected override void OnAwake()
    {
        GameManagerBase.ReadyToAssignObjects += () => GameManagerBase.Instance.Builder = this;
    }

    protected override void OnStart()
    {
        GameManagerBase.Instance.GameParameters.InputService.ToggleBuildStarted += ToggleBuilderGameState;

        BuilderGameStateEnabled += SubscribeBuilderMethods;
        BuilderGameStateDisabled += UnsubscribeBuilderMethods;
    }

    public GameObject InstantiateBuilderPrefab(GameObject builderPrefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(builderPrefab, position, rotation, transform);
        WallBuilderItems.Add(FloorHandler.CurrentFloor, (newObject.GetComponent<IBuilderItem>() as IWallBuilderItem)!);

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

    public void AddBuilderItemBasedOnType(IBuilderItem itemToAdd)
    {
        switch (itemToAdd)
        {
            case IWallBuilderItem wbi:
                WallBuilderItems.Add(FloorHandler.CurrentFloor, wbi);
                break;
            case IFloorBuilderItem fbi:
                FloorBuilderItems.Add(FloorHandler.CurrentFloor, fbi);
                break;
        }
    }
    
    public void RemoveBuilderItemBasedOnType(IBuilderItem itemToAdd)
    {
        switch (itemToAdd)
        {
            case IWallBuilderItem wbi:
                WallBuilderItems.Remove(FloorHandler.CurrentFloor, wbi);
                break;
            case IFloorBuilderItem fbi:
                FloorBuilderItems.Remove(FloorHandler.CurrentFloor, fbi);
                break;
        }
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