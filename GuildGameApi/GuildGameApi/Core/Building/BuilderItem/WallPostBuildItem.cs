﻿using UnityEngine;

namespace com.Halcyon.API.Core.Building.BuilderItem;

public class WallPostBuildItem : MonoBehaviour, IWallBuilderItem
{
    private BuilderItemType _builderItemType = BuilderItemType.WallPost;

    public BuilderItemType BuilderItemType
    {
        get => _builderItemType;
        set => _builderItemType = value;
    }
    
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
}