using UnityEngine;

namespace com.Halcyon.API.Core.Building.BuilderItem;

public class WallBuildItem : ExtendedMonoBehaviour, IWallBuilderItem
{
    private BuilderItemType _builderItemType = BuilderItemType.Wall;
    private Renderer? _renderer;

    protected override void OnAwake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public BuilderItemType BuilderItemType
    {
        get => _builderItemType;
        set => _builderItemType = value;
    }

    public void Show()
    {
        if (_renderer != null) _renderer.enabled = true;
    }

    public void Hide()
    {
        if (_renderer != null) _renderer.enabled = false;
    }
}