using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Core.Building.BuilderItem;
using UnityEngine;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableBuilderItem
{
    private BuilderItemType _builderItemType;
    private SerializableVector3 _position;
    private SerializableQuaternion _rotation;

    public BuilderItemType BuilderItemType
    {
        get => _builderItemType;
        set => _builderItemType = value;
    }

    public SerializableVector3 Position
    {
        get => _position;
        set => _position = value;
    }

    public SerializableQuaternion Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }

    public SerializableBuilderItem(BuilderItemType builderItemType, SerializableVector3 position,
        SerializableQuaternion rotation)
    {
        _builderItemType = builderItemType;
        _position = position;
        _rotation = rotation;
    }

    public static List<SerializableBuilderItem> GetBuilderItemsFromInterfaceList(List<IBuilderItem> builderItems)
    {
        List<SerializableBuilderItem> newBuilderItems = new List<SerializableBuilderItem>();
        foreach (IBuilderItem builderItem in builderItems)
        {
            SerializableBuilderItem newSerializableBuilderItem = new SerializableBuilderItem(
                builderItem.BuilderItemType,
                new SerializableVector3(builderItem.Position), new SerializableQuaternion(builderItem.Rotation));

            newBuilderItems.Add(newSerializableBuilderItem);
        }

        return newBuilderItems;
    }

    public static List<IBuilderItem> InstantiateItemsAndReferences(List<SerializableBuilderItem> builderItems)
    {
        List<IBuilderItem> newBuilderItems = new List<IBuilderItem>();
        foreach (SerializableBuilderItem builderItem in builderItems)
        {
            GameObject prefab = GameManagerBase.Instance.Builder.GetPrefabBasedOnType(builderItem.BuilderItemType);

            GameObject go = GameManagerBase.Instance.Builder.InstantiateBuilderPrefab(prefab, builderItem.Position.GetUnityVector(),
                builderItem.Rotation.GetUnityQuaternion());

            IBuilderItem builderItemInterface = go.GetComponent<IBuilderItem>();

            newBuilderItems.Add(builderItemInterface);
        }

        return newBuilderItems;
    }
}