using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder.FloorBuilder
{
    public class Floor : ExtendedMonoBehaviour
    {
        [SerializeField] private int floorIndex;
        private AreaCollider _areaCollider;
        private MeshCollider _meshCollider;
        private Renderer _renderer;

        public int FloorIndex
        {
            get => floorIndex;
            set => floorIndex = value;
        }

        protected override void OnAwake()
        {
            _areaCollider = GetComponentInChildren<AreaCollider>();
            _meshCollider = GetComponent<MeshCollider>();
            _renderer = GetComponent<Renderer>();
            
            BuilderAbstract.BuilderInitialisationCompleted += SetActiveBasedOnFloorIndex;
            BuilderAbstract.BuilderInitialisationCompleted += () =>
                GameManager.Instance.Builder.FloorHandler.OnFloorChanged += OnFloorChanged;
        }

        protected override void OnStart()
        {
            _areaCollider.BoxCollider.center = CalculateColliderCenter();
            _areaCollider.BoxCollider.size = CalculateColliderSize();
        }

        private void OnFloorChanged(int newFloorIndex)
        {
            if (floorIndex <= newFloorIndex)
            {
                if (_areaCollider.enabled)
                {
                    _areaCollider.EnableAllRenderers();
                }
                
                EnableFloor();
            }
            else if (floorIndex > newFloorIndex)
            {
                DisableFloor();
            }
        }

        private void EnableFloor()
        {
            _renderer.enabled = true;
            _meshCollider.enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            _areaCollider.enabled = false;
        }

        private void DisableFloor()
        {
            _renderer.enabled = false;
            _meshCollider.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            _areaCollider.enabled = true;
        }

        private void SetActiveBasedOnFloorIndex()
        {
            Builder builder = GameManager.Instance.Builder as Builder;
            if (builder!.FloorHandler.CurrentFloor < floorIndex)
            {
                DisableFloor();
            }
            else
            {
                EnableFloor();
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
                Constants.BuilderConstants.FloorHeight / 2, Constants.BuilderConstants.MaxUnityGridSize);
            return size;
        }
    }
}