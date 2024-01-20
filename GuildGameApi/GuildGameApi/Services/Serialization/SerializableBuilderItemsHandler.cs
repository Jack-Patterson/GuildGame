using com.Halcyon.API.Core.Building.BuilderItem;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableBuilderItemsHandler
{
    public List<SerializableBuilderItem> FirstFloorItems { get; }
    public List<SerializableBuilderItem> SecondFloorItems { get; }
    public List<SerializableBuilderItem> ThirdFloorItems { get; }
    
    public SerializableBuilderItemsHandler(BuilderItemsHandler<IBuilderItem> builderItemsHandler)
    {
        FirstFloorItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(builderItemsHandler.FirstFloorItems);
        SecondFloorItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(builderItemsHandler.SecondFloorItems);
        ThirdFloorItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(builderItemsHandler.ThirdFloorItems);
    }

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
        List<T> firstFloorItems = SerializableBuilderItem.InstantiateItemsAndReferences(FirstFloorItems) as List<T>;
        List<T> secondFloorItems = SerializableBuilderItem.InstantiateItemsAndReferences(SecondFloorItems) as List<T>;
        List<T> thirdFloorItems = SerializableBuilderItem.InstantiateItemsAndReferences(ThirdFloorItems) as List<T>;
        
        builderItemsHandler.Add(1, firstFloorItems);
        builderItemsHandler.Add(2, secondFloorItems);
        builderItemsHandler.Add(3, thirdFloorItems);

        return builderItemsHandler;
    }
}