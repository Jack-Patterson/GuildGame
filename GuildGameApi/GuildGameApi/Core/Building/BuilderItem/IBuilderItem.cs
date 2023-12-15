using UnityEngine;

namespace com.Halcyon.API.Core.Building.BuilderItem;

public interface IBuilderItem
{
    BuilderItemType BuilderItemType { get; set; }
    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
}