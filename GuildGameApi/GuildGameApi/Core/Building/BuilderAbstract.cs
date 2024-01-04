using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Services.Logger;
using UnityEngine;

namespace com.Halcyon.API.Core.Building;

public abstract class BuilderAbstract : MonoBehaviour
{
    [SerializeField] protected GameObject pointer = null!;
    [SerializeField] protected GameObject wallPrefab = null!;
    [SerializeField] protected GameObject wallPostPrefab = null!;
    [SerializeField] protected LayerMask placeRaycast;
    [SerializeField] protected LayerMask wallLayer;

    public event Action? BuilderGameStateEnabled;
    public event Action? BuilderGameStateDisabled;
    // public event Action? BuilderGameStateEnabled;
    // public event Action? BuilderGameStateDisabled;
    private List<IBuilderItem> _builderItems = new List<IBuilderItem>();

    public List<IBuilderItem> BuilderItems => _builderItems;

    public IBuilderItem AddBuilderItem
    {
        set => BuilderItems.Add(value);
    }

    private void OnDisable()
    {
        BuilderGameStateDisabled?.Invoke();
    }

    protected void Start()
    {
        GameManagerBase.Instance.Builder = this;
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

    protected bool IsInBuildMode() => GameManagerBase.Instance.GameParameters.GameState == GameState.Building;

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

    protected abstract void OnBuilderGameStateEnabled();

    protected abstract void OnBuilderGameStateDisabled();
}