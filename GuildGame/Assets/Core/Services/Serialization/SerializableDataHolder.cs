using System.Collections.Generic;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Camera;

namespace com.Halcyon.Core.Services.Serialization
{
    public class SerializableDataHolder
    {
        private List<SerializableBuilderItem> _serializableBuilderItems;
        private CameraParameters _cameraParameters;

        public CameraParameters CameraParameters
        {
            get => _cameraParameters;
            set => _cameraParameters = value;
        }

        public List<SerializableBuilderItem> SerializableBuilderItems
        {
            get => _serializableBuilderItems;
            set => _serializableBuilderItems = value;
        }
    
        public SerializableDataHolder()
        {
            _serializableBuilderItems = new List<SerializableBuilderItem>();
        }
    
        public SerializableDataHolder(List<SerializableBuilderItem> serializableBuilderItems, CameraParameters cameraParameters)
        {
            _serializableBuilderItems = serializableBuilderItems;
            _cameraParameters = cameraParameters;
        }

        public SerializableDataHolder(List<IBuilderItem> builderItems, CameraParameters cameraParameters)
        {
            _serializableBuilderItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(builderItems);
            _cameraParameters = cameraParameters;
        }

        public SerializableDataHolder(DataHolder.DataHolder dataHolder)
        {
            _serializableBuilderItems = SerializableBuilderItem.GetBuilderItemsFromInterfaceList(dataHolder.BuilderItems);
            _cameraParameters = dataHolder.CameraParameters as CameraParameters;
        }

        public DataHolder.DataHolder ToDataHolder() => new DataHolder.DataHolder(SerializableBuilderItems, _cameraParameters as ICameraParameters);
    }
}