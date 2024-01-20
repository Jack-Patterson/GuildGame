using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.Serialization;

namespace com.Halcyon.API.Services.DataHolder;

public abstract class DataHolderAbstract : IDataHolderService
{
    public BuilderItemsHandler<IWallBuilderItem> WallBuilderItemsHandler => GameManagerBase.Instance.Builder.WallBuilderItems;

    public ICameraParameters CameraParameters
    {
        get => GameManagerBase.Instance.CameraParameters;
        set => GameManagerBase.Instance.CameraParameters = value;
    }

    protected DataHolderAbstract()
    {
    }

    protected DataHolderAbstract(BuilderItemsHandler<IWallBuilderItem> wallBuilderItemsHandler, ICameraParameters cameraParameters)
    {
        // WallBuilderItemsHandler = wallBuilderItemsHandler;
        CameraParameters = cameraParameters;
    }

    public abstract bool SaveData(string relativeSaveLocation);
    public abstract IDataHolderService LoadData(string relativeSaveLocation);
}