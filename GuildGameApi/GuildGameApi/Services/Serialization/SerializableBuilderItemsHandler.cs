using com.Halcyon.API.Core.Building.BuilderItem;
using UnityEngine;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableBuilderItemsHandler
{
    public List<SerializableBuilderItem> FirstFloorItems { get; }
    public List<SerializableBuilderItem> SecondFloorItems { get; }
    public List<SerializableBuilderItem> ThirdFloorItems { get; }

    public SerializableBuilderItemsHandler(List<SerializableBuilderItem> firstFloorItems,
        List<SerializableBuilderItem> secondFloorItems, List<SerializableBuilderItem> thirdFloorItems)
    {
        FirstFloorItems = firstFloorItems;
        SecondFloorItems = secondFloorItems;
        ThirdFloorItems = thirdFloorItems;
    }

    public BuilderItemsHandler<T> ToBuilderItemsHandler<T>() where T : IBuilderItem
    {
        BuilderItemsHandler<T> builderItemsHandler = new BuilderItemsHandler<T>();
        List<T> firstFloorItems = SerializableBuilderItem.InstantiateItemsAndReferences<T>(FirstFloorItems);
        List<T> secondFloorItems = SerializableBuilderItem.InstantiateItemsAndReferences<T>(SecondFloorItems);
        List<T> thirdFloorItems = SerializableBuilderItem.InstantiateItemsAndReferences<T>(ThirdFloorItems);
        
        builderItemsHandler.Add(1, firstFloorItems);
        builderItemsHandler.Add(2, secondFloorItems);
        builderItemsHandler.Add(3, thirdFloorItems);

        return builderItemsHandler;
    }
}