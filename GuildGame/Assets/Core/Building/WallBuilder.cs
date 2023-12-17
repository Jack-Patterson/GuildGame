using System;
using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.Core.Manager;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.Halcyon.Core.Building
{
    public class WallBuilder
    {
        private readonly LayerMask _placeRaycast;
        private readonly LayerMask _wallLayer;
        private const float WallGridSize = 10f;

        private GameObject _wallPrefab;
        private GameObject _wallPostPrefab;
        private Builder _builder;
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

        public WallBuilder(GameObject wallPrefab, GameObject wallPostPrefab, LayerMask placeRaycast,
            LayerMask wallLayer, Builder builder)
        {
            _wallPrefab = wallPrefab;
            _wallPostPrefab = wallPostPrefab;
            _placeRaycast = placeRaycast;
            _wallLayer = wallLayer;
            _builder = builder;
        }

        internal void DrawWall(Vector2 vector)
        {
            if (!_isDrawingCreation || Utils.ValidateVectorSameAsAnother(CurrentPosition, LastPosition) ||
                GameManager.Instance.GameParameters.GameState != GameState.Building)
                return;

            Vector3 instantiationPoint = (CurrentPosition + LastPosition) / 2;
            instantiationPoint.y += 5f;

            Collider[] colliders = Physics.OverlapSphere(
                new Vector3(instantiationPoint.x, instantiationPoint.y + 2f, instantiationPoint.z), 1f,
                _wallLayer);

            bool shouldInstantiateWall = Utils.GetComponentFromColliderArray<WallBuildItem>(colliders) == null;
            bool wallPositionValid = ValidateWallPlacePosition(instantiationPoint);

            if (shouldInstantiateWall && wallPositionValid)
            {
                bool shouldRotatePrefab = Math.Abs(instantiationPoint.x) != Math.Abs(CurrentPosition.x);
                Quaternion rotation = Quaternion.Euler(0, shouldRotatePrefab ? 0 : 90, 0);

                _builder.InstantiateBuilderPrefab(_wallPrefab, instantiationPoint, rotation);

                PlacePost(instantiationPoint, rotation);
            }
        }

        private void PlacePost(Vector3 wallPosition, Quaternion rotation)
        {
            Vector3 possiblePostPositionOne = rotation.eulerAngles.y != 90f
                ? new Vector3(wallPosition.x + 5f, wallPosition.y, wallPosition.z)
                : new Vector3(wallPosition.x, wallPosition.y, wallPosition.z + 5f);
            Vector3 possiblePostPositionTwo = rotation.eulerAngles.y != 90f
                ? new Vector3(wallPosition.x - 5f, wallPosition.y, wallPosition.z)
                : new Vector3(wallPosition.x, wallPosition.y, wallPosition.z - 5f);

            Collider[] colliders = Physics.OverlapSphere(
                new Vector3(possiblePostPositionOne.x, possiblePostPositionOne.y + 2f, possiblePostPositionOne.z), 1f,
                _wallLayer);
            bool shouldPlaceWall = Utils.GetComponentFromColliderArray<WallPostBuildItem>(colliders) == null;

            if (shouldPlaceWall)
                _builder.InstantiateBuilderPrefab(_wallPostPrefab, possiblePostPositionOne, rotation);

            colliders = Physics.OverlapSphere(
                new Vector3(possiblePostPositionTwo.x, possiblePostPositionTwo.y + 2f, possiblePostPositionTwo.z), 1f,
                _wallLayer);

            shouldPlaceWall = Utils.GetComponentFromColliderArray<WallPostBuildItem>(colliders) == null;

            if (shouldPlaceWall)
                _builder.InstantiateBuilderPrefab(_wallPostPrefab, possiblePostPositionTwo, rotation);
        }

        internal void DestroyWall(Vector2 vector)
        {
            if (!_isDrawingDestruction || Utils.ValidateVectorSameAsAnother(CurrentPosition, LastPosition) ||
                GameManager.Instance.GameParameters.GameState != GameState.Building)
                return;

            Vector3 expectedObjectPosition = (CurrentPosition + LastPosition) / 2;

            Collider[] colliders = Physics.OverlapSphere(
                new Vector3(expectedObjectPosition.x, expectedObjectPosition.y + 2f, expectedObjectPosition.z), 1f,
                _wallLayer);

            WallBuildItem wallToDestroy = Utils.GetComponentFromColliderArray<WallBuildItem>(colliders);
            bool wallPositionValid = ValidateWallPlacePosition(expectedObjectPosition);

            if (wallToDestroy != null && wallPositionValid)
            {
                Object.Destroy(wallToDestroy.gameObject);
            }
        }

        internal Vector3 PointToPosition()
        {
            // Ray ray = Camera.main.ScreenPointToRay(_currentMousePosition);
            // RaycastHit hit;
            //
            // if (Physics.Raycast(ray, out hit, 1000f, _placeRaycast))
            // {
            //     if (hit.collider.GetComponent<IBuilderItem>() != null)
            //         return SnapToGrid(_lastPosition);
            //         
            //     return SnapToGrid(hit.point);
            // }
            //
            return SnapToGrid(_lastPosition);
        }

        internal void ToggleIsDrawingWallCreation()
        {
            _isDrawingCreation = !_isDrawingCreation;
        }

        internal void ToggleIsDrawingWallDestruction()
        {
            _isDrawingDestruction = !_isDrawingDestruction;
        }

        internal void UpdateCurrentMousePosition(Vector2 value)
        {
            _currentMousePosition = value;
        }

        private bool ValidateWallPlacePosition(Vector3 vector)
        {
            int xMod5 = (int)vector.x % 5;
            int zMod5 = (int)vector.z % 5;
            int xMod10 = (int)vector.x % 10;
            int zMod10 = (int)vector.z % 10;

            return (xMod5 == 0 && zMod10 == 0) || (xMod10 == 0 && zMod5 == 0);
        }

        private Vector3 SnapToGrid(Vector3 position)
        {
            float x = Mathf.Round(position.x / WallGridSize) * WallGridSize;
            float z = Mathf.Round(position.z / WallGridSize) * WallGridSize;

            return new Vector3(x, position.y, z);
        }
    }
}