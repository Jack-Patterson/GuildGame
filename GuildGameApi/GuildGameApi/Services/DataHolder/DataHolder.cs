using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Services.Serialization;

namespace com.Halcyon.API.Services.DataHolder;

public class DataHolder : IDataHolderService
{
    public List<IBuilderItem> BuilderItems => GameManagerBase.Instance.Builder.BuilderItems;

    public DataHolder()
    {
    }

    public DataHolder(List<SerializableBuilderItem> builderItems)
    {
        SerializableBuilderItem.InstantiateItemsAndReferences(builderItems);
    }

    public bool SaveData(string relativeSaveLocation)
    {
        return GameManagerBase.Instance.GameParameters.JsonSerializationService.SaveData(
            new SerializableDataHolder(this), relativeSaveLocation);
    }

    public IDataHolderService LoadData(string relativeSaveLocation)
    {
        return (GameManagerBase.Instance.GameParameters.JsonSerializationService.LoadData<SerializableDataHolder>(
            relativeSaveLocation)).ToDataHolder();
    }
}