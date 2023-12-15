using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Logger;
using UnityEngine;

namespace com.Halcyon.API.Core.Building;

public abstract class BuilderAbstract : MonoBehaviour
{
    [SerializeField] protected GameObject pointer = null!;
    [SerializeField] protected GameObject wallPrefab = null!;
    [SerializeField] protected GameObject wallPostPrefab = null!;
    [SerializeField] protected LayerMask placeRaycast;
    [SerializeField] protected LayerMask wallLayer;

    protected event Action? BuilderGameStateEnabled;
    protected event Action? BuilderGameStateDisabled;
    private List<IBuilderItem> _builderItems = new List<IBuilderItem>();

    public List<IBuilderItem> BuilderItems => _builderItems;

    public IBuilderItem AddBuilderItem
    {
        set => BuilderItems.Add(value);
    }
    
    protected void Start()
    {
        GameManagerBase.Instance.GameParameters.InputService.ToggleBuildStarted += ToggleBuilderGameState;

        BuilderGameStateEnabled += OnBuilderGameStateEnabled;
        BuilderGameStateDisabled += OnBuilderGameStateDisabled;
    }

    public GameObject InstantiateBuilderPrefab(GameObject wallPrefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(wallPrefab, position, rotation, transform);
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

    protected bool IsInBuildMode()
    {
        return GameManagerBase.Instance.GameParameters.GameState == GameState.Building;
    }

    protected void ToggleBuilderGameState()
    {
        if (GameManagerBase.Instance.GameParameters.GameState == GameState.Building)
        {
            GameLogger.Log("Disabling building mode.");

            GameManagerBase.Instance.GameParameters.GameState = GameState.GameBase;
            BuilderGameStateDisabled?.Invoke();
        }
        else
        {
            GameLogger.Log("Enabling building mode.");

            GameManagerBase.Instance.GameParameters.GameState = GameState.Building;
            BuilderGameStateEnabled?.Invoke();
        }
    }

    protected abstract void OnBuilderGameStateEnabled();

    protected abstract void OnBuilderGameStateDisabled();
}