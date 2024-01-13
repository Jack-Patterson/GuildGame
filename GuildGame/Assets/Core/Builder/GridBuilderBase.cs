using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal abstract class GridBuilderBase : BuilderSubscriberItem
    {
        protected readonly LayerMask PlaceRaycast;
        protected readonly LayerMask WallLayer;
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
        
        protected float WallGridSize => _wallGridSize;

        protected bool IsBuildModeEnabled => GameManager.Instance.GameParameters.GameState == GameState.Building;
        
        protected GridBuilderBase(LayerMask placeRaycast, LayerMask wallLayer)
        {
            PlaceRaycast = placeRaycast;
            WallLayer = wallLayer;
        }

        protected GridBuilderBase(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer)
        {
            _wallGridSize = wallGridSize;
            PlaceRaycast = placeRaycast;
            WallLayer = wallLayer;
        }
        
        internal Vector3 SnapToGrid(Vector3 position)
        {
            float x = Mathf.Round(position.x / _wallGridSize) * _wallGridSize;
            float z = Mathf.Round(position.z / _wallGridSize) * _wallGridSize;

            return new Vector3(x, position.y, z);
        }
        
        internal void ToggleIsDrawingWallCreation()
        {
            if (!IsBuildModeEnabled)
                return;
            
            _isDrawingCreation = !_isDrawingCreation;
        }

        internal void ToggleIsDrawingWallDestruction()
        {
            if (!IsBuildModeEnabled)
                return;
            
            _isDrawingDestruction = !_isDrawingDestruction;
        }

        protected void DrawEvent(Vector2 vector)
        {
            if (!IsBuildModeEnabled || (!IsDrawingCreation && !IsDrawingDestruction) || Utils.ValidateVectorSameAsAnother(CurrentPosition, LastPosition))
                return;
            
            Builder builder = GameManager.Instance.Builder as Builder;
            Draw(builder!.transform, builder.GetPrefabs(this));
        }
        
        internal void UpdateCurrentMousePosition(Vector2 value)
        {
            if (!IsBuildModeEnabled)
                return;
            
            _currentMousePosition = value;
        }

        protected void Create(Transform parent, GameObject prefabToUse, Vector3 position, Quaternion rotation)
        {
            Object.Instantiate(prefabToUse, position, rotation, parent);
            
            GameLogger.Log($"Creating build object at position (Vector3: {position}) with the rotation (Quaternion: {rotation}, EulerAngles: {rotation.eulerAngles}).");
        }

        protected void Create(GameObject parent, GameObject prefabToUse, Vector3 position, Quaternion rotation)
        {
            Create(parent.transform, prefabToUse, position, rotation);
        }

        protected void Destroy(GameObject gameObject)
        {
            Object.Destroy(gameObject);
            
            GameLogger.Log($"Destroying build object at position (Vector3: {gameObject.transform.position}).");
        }

        protected abstract void Draw(Transform builder, List<GameObject> prefabsToUse);
        protected abstract void OnMousePositionChanged(RaycastHit value);
    }
}