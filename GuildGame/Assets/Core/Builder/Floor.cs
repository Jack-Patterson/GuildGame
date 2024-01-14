using com.Halcyon.API.Core;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    [RequireComponent(typeof(BoxCollider))]
    public class Floor : ExtendedMonoBehaviour
    {
        [SerializeField] private int floorIndex;
        private BoxCollider _boxCollider;
        private MeshCollider _meshCollider;
        private Renderer _renderer;

        public int FloorIndex
        {
            get => floorIndex;
            set => floorIndex = value;
        }

        protected override void OnAwake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _meshCollider = GetComponent<MeshCollider>();
            _renderer = GetComponent<Renderer>();
        }

        protected override void OnStart()
        {
            _boxCollider.center = CalculateColliderCenter();
            _boxCollider.size = CalculateColliderSize();

            GameManager.Instance.Builder.BuilderInitialisationCompleted += SetActiveBasedOnFloorIndex;
        }

        private void SetActiveBasedOnFloorIndex()
        {
            Builder builder = GameManager.Instance.Builder as Builder;
            if (builder!.FloorHandler.CurrentFloor < floorIndex)
            {
                _renderer.enabled = false;
                _meshCollider.enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        private Vector3 CalculateColliderCenter()
        {
            Vector3 center = new Vector3(0, Constants.BuilderConstants.FloorHeight / 2, 0);
            return center;
        }

        private Vector3 CalculateColliderSize()
        {
            Vector3 size = new Vector3(Constants.BuilderConstants.MaxUnityGridSize,
                Constants.BuilderConstants.FloorHeight, Constants.BuilderConstants.MaxUnityGridSize);
            return size;
        }
    }
}