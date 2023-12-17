using com.Halcyon.API.Core.Building.BuilderItem;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableDataHolder
{
    private List<SerializableBuilderItem> _serializableBuilderItems;

    public List<SerializableBuilderItem> SerializableBuilderItems
    {
        get => _serializableBuilderItems;
        set => _serializableBuilderItems = value;
    }
    
    public SerializableDataHolder()
    {
        _serializableBuilderItems = new List<SerializableBuilderItem>();
    }
    
    public SerializableDataHolder(List<SerializableBuilderItem> serializableBuilderItems)
    {
        _serializableBuilderItems = serializableBuilderItems;
    }

    public SerializableDataHolder(List<IBuilderItem> builderItems)
    {
        _serializableBuilderItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(builderItems);
    }

    public DataHolder.DataHolder ToDataHolder() => new DataHolder.DataHolder(SerializableBuilderItems);

    public SerializableDataHolder(DataHolder.DataHolder dataHolder)
    {
        _serializableBuilderItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(dataHolder.BuilderItems);
    }
}