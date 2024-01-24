using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Camera;

namespace com.Halcyon.Core.Services.Serialization
{
    public class SerializableDataHolder
    {
        private SerializableBuilderItemsHandler _wallBuilderItemsHandler;
        private CameraParameters _cameraParameters;

        public CameraParameters CameraParameters
        {
            get => _cameraParameters;
            set => _cameraParameters = value;
        }

        public SerializableBuilderItemsHandler WallBuilderItemsHandler
        {
            get => _wallBuilderItemsHandler;
            set => _wallBuilderItemsHandler = value;
        }

        public SerializableDataHolder()
        {
            // _wallBuilderItemsHandler = new SerializableBuilderItemsHandler();
        }

        public SerializableDataHolder(BuilderItemsHandler<IWallBuilderItem> wallBuilderItemsHandler,
            CameraParameters cameraParameters)
        {
            _wallBuilderItemsHandler = new SerializableBuilderItemsHandler(
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(wallBuilderItemsHandler.FirstFloorItems),
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(wallBuilderItemsHandler.SecondFloorItems),
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(wallBuilderItemsHandler.ThirdFloorItems));
            _cameraParameters = cameraParameters;
        }

        public SerializableDataHolder(DataHolder.DataHolder dataHolder)
        {
            _wallBuilderItemsHandler = new SerializableBuilderItemsHandler(
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(dataHolder.WallBuilderItemsHandler
                    .FirstFloorItems),
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(dataHolder.WallBuilderItemsHandler
                    .SecondFloorItems),
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(dataHolder.WallBuilderItemsHandler
                    .ThirdFloorItems));
            _cameraParameters = dataHolder.CameraParameters as CameraParameters;
        }

        public SerializableDataHolder(SerializableBuilderItemsHandler wallBuilderItemsHandler,
            CameraParameters cameraParameters)
        {
            _wallBuilderItemsHandler = wallBuilderItemsHandler;
            _cameraParameters = cameraParameters;
        }

        public DataHolder.DataHolder ToDataHolder() =>
            new DataHolder.DataHolder(WallBuilderItemsHandler.ToBuilderItemsHandler<IWallBuilderItem>(),
                _cameraParameters as ICameraParameters);
    }
}