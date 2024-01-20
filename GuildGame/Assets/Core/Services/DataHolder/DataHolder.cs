using System.Collections.Generic;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.DataHolder;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Manager;
using com.Halcyon.Core.Services.Serialization;

namespace com.Halcyon.Core.Services.DataHolder
{
    public class DataHolder : DataHolderAbstract
    {
        public DataHolder()
        {
        }

        public DataHolder(BuilderItemsHandler<IWallBuilderItem> wallBuilderItems, ICameraParameters cameraParameters) : base(
            wallBuilderItems, cameraParameters)
        {
        }

        public override bool SaveData(string relativeSaveLocation)
        {
            return GameManager.Instance.GameParameters.JsonSerializationService.SaveData(
                new SerializableDataHolder(this),
                relativeSaveLocation);
        }

        public override IDataHolderService LoadData(string relativeSaveLocation)
        {
            return (GameManager.Instance.GameParameters.JsonSerializationService.LoadData<SerializableDataHolder>(
                relativeSaveLocation)).ToDataHolder();
        }
    }
}