using com.Halcyon.API.Core.Building.BuilderItem;

namespace com.Halcyon.API.Services.DataHolder;

public interface IDataHolderService
{
    List<IBuilderItem> BuilderItems { get; }

    bool SaveData(string relativeSaveLocation);
    IDataHolderService LoadData(string relativeSaveLocation);
}