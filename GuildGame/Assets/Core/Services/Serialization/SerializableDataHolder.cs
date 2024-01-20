using System.Collections.Generic;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Camera;

namespace com.Halcyon.Core.Services.Serialization
{
    public class SerializableDataHolder
    {
        private BuilderItemsHandler<IWallBuilderItem> _wallBuilderItemsHandler;
        private CameraParameters _cameraParameters;

        public CameraParameters CameraParameters
        {
            get => _cameraParameters;
            set => _cameraParameters = value;
        }

        public BuilderItemsHandler<IWallBuilderItem> WallBuilderItemsHandler
        {
            get => _wallBuilderItemsHandler;
            set => _wallBuilderItemsHandler = value;
        }

        public SerializableDataHolder()
        {
            _wallBuilderItemsHandler = new BuilderItemsHandler<IWallBuilderItem>();
        }

        public SerializableDataHolder(BuilderItemsHandler<IWallBuilderItem> wallBuilderItemsHandler,
            CameraParameters cameraParameters)
        {
            _wallBuilderItemsHandler = wallBuilderItemsHandler;
            _cameraParameters = cameraParameters;
        }

        public SerializableDataHolder(DataHolder.DataHolder dataHolder)
        {
            _wallBuilderItemsHandler = dataHolder.WallBuilderItemsHandler;
            _cameraParameters = dataHolder.CameraParameters as CameraParameters;
        }

        public DataHolder.DataHolder ToDataHolder() =>
            new DataHolder.DataHolder(WallBuilderItemsHandler, _cameraParameters as ICameraParameters);
    }
}