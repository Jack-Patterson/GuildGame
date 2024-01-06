using System.Collections.Generic;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal abstract class GridBuilderBase : BuilderSubscriberItem
    {
        private readonly LayerMask _placeRaycast;
        private readonly LayerMask _wallLayer;
        private readonly float _wallGridSize = Constants.DefaultGridSize;
        
        private Vector3 _currentPosition = Vector3.zero;
        private Vector3 _lastPosition = Vector3.zero;
        private Vector2 _currentMousePosition = Vector2.zero;
        private bool _isDrawingCreation = false;
        private bool _isDrawingDestruction = false;

        public Vector3 CurrentPosition
        {
            get => _currentPosition;
            set => _currentPosition = value;
        }

        public Vector3 LastPosition
        {
            get => _lastPosition;
            set => _lastPosition = value;
        }

        public Vector2 CurrentMousePosition
        {
            get => _currentMousePosition;
            set => _currentMousePosition = value;
        }

        public bool IsDrawingCreation
        {
            get => _isDrawingCreation;
            set => _isDrawingCreation = value;
        }

        public bool IsDrawingDestruction
        {
            get => _isDrawingDestruction;
            set => _isDrawingDestruction = value;
        }
        
        protected GridBuilderBase(LayerMask placeRaycast, LayerMask wallLayer)
        {
            _placeRaycast = placeRaycast;
            _wallLayer = wallLayer;
        }

        protected GridBuilderBase(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer)
        {
            _wallGridSize = wallGridSize;
            _placeRaycast = placeRaycast;
            _wallLayer = wallLayer;
        }
        
        internal Vector3 PointToPosition()
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(CurrentMousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, _placeRaycast))
            {
                if (hit.collider.GetComponent<IBuilderItem>() != null)
                    return SnapToGrid(LastPosition);
                GameLogger.Log(("Hitting position", hit.point));
                return SnapToGrid(hit.point);
            }

            return SnapToGrid(LastPosition);
        }
        
        internal Vector3 SnapToGrid(Vector3 position)
        {
            float x = Mathf.Round(position.x / _wallGridSize) * _wallGridSize;
            float z = Mathf.Round(position.z / _wallGridSize) * _wallGridSize;

            return new Vector3(x, position.y, z);
        }
        
        internal void ToggleIsDrawingWallCreation()
        {
            _isDrawingCreation = !_isDrawingCreation;
        }

        internal void ToggleIsDrawingWallDestruction()
        {
            _isDrawingDestruction = !_isDrawingDestruction;
        }

        internal void DrawEvent(Vector2 vector)
        {
            Builder builder = GameManager.Instance.Builder as Builder;
            Draw(builder, builder!.GetPrefabs(this));
            GameLogger.Log(vector);
        }
        
        internal void DestroyEvent(Vector2 vector)
        {
            Builder builder = GameManager.Instance.Builder as Builder;
            Destroy(builder);
        }
        
        internal void UpdateCurrentMousePosition(Vector2 value)
        {
            _currentMousePosition = value;
        }

        protected abstract void Draw(Builder builder, List<GameObject> prefabToUse);
        protected abstract void Create(Builder builder, List<GameObject> prefabToUse);
        protected abstract void Destroy(Builder builder);
    }
}