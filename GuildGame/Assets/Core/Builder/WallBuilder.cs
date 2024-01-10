using System;
using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Services.Input;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal class WallBuilder : GridBuilderBase
    {
        public WallBuilder(LayerMask placeRaycast, LayerMask wallLayer) : base(placeRaycast, wallLayer)
        {
        }

        public WallBuilder(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer) : base(wallGridSize,
            placeRaycast, wallLayer)
        {
        }

        protected override void Draw(Builder builder, List<GameObject> prefabsToUse)
        {
            if (!IsDrawingCreation || Utils.ValidateVectorSameAsAnother(CurrentPosition, LastPosition))
                return;

            float rotationAngleTrue = 0f;
            float rotationAngleFalse = 90f;

            Vector3 instantiationPoint = (CurrentPosition + LastPosition) / 2;
            instantiationPoint.y += Constants.FloorHeight;

            float absoluteInstantiationX = Math.Abs(instantiationPoint.x);
            float absoluteCurrentX = Math.Abs(CurrentPosition.x);
            bool shouldRotatePrefab = !absoluteInstantiationX.Equals(absoluteCurrentX);
            float rotationYAngle = shouldRotatePrefab ? rotationAngleTrue : rotationAngleFalse;
            Quaternion rotation = Quaternion.Euler(0f, rotationYAngle, 0f);

            Vector3 overlapSpherePosition = new Vector3(instantiationPoint.x,
                instantiationPoint.y - Constants.FloorHeight / 2, instantiationPoint.z);
            
            bool shouldInstantiateWall = !Utils.OverlapAreaContainsItem<WallBuildItem>(overlapSpherePosition, Constants.WallCheckRadius, WallLayer);
            bool wallPositionValid = ValidateWallPlacePosition(instantiationPoint);
            
            if (shouldInstantiateWall && wallPositionValid)
            {
                GameObject prefabToUse = Utils.GetPrefabFromListByScript<WallBuildItem>(prefabsToUse);

                if (prefabToUse == null)
                {
                    GameLogger.Log("No prefab found which is a WallBuildItem.", LogType.Error);
                    return;
                }

                Create(builder.transform, prefabToUse, instantiationPoint, rotation);

                // PlacePosts(instantiationPoint, rotation, prefabsToUse);
            }
        }

        private void PlacePosts(Vector3 wallPosition, Quaternion rotation, List<GameObject> prefabsToUse)
        {
            bool wallIsRotated = rotation.eulerAngles.y.Equals(90f);

            Vector3 firstPossiblePostPosition = !wallIsRotated
                ? new Vector3(wallPosition.x + 5f, wallPosition.y, wallPosition.z)
                : new Vector3(wallPosition.x, wallPosition.y, wallPosition.z + 5f);
            Vector3 secondPossiblePostPosition = !wallIsRotated
                ? new Vector3(wallPosition.x - 5f, wallPosition.y, wallPosition.z)
                : new Vector3(wallPosition.x, wallPosition.y, wallPosition.z - 5f);
            
            
        }

        private bool ValidateWallPlacePosition(Vector3 vector)
        {
            int xMod5 = (int)vector.x % 5;
            int zMod5 = (int)vector.z % 5;
            int xMod10 = (int)vector.x % 10;
            int zMod10 = (int)vector.z % 10;

            return (xMod5 == 0 && zMod10 == 0) || (xMod10 == 0 && zMod5 == 0);
        }

        protected override void Destroy(Builder builder)
        {
            if (!IsDrawingDestruction || Utils.ValidateVectorSameAsAnother(CurrentPosition, LastPosition))
                return;

            GameLogger.Log("destroying");
        }

        protected override void SubscribeGridBuildMethods()
        {
            IInputService inputService = GameManager.Instance.GameParameters.InputService;
            Builder builder = GameManager.Instance.Builder as Builder;

            inputService.MousePositionPerformed += UpdateCurrentMousePosition;
            inputService.MousePositionPerformed += DrawEvent;
            inputService.MousePositionPerformed += DestroyEvent;
            inputService.Mouse1PressStarted += ToggleIsDrawingWallCreation;
            inputService.Mouse1PressEnded += ToggleIsDrawingWallCreation;
            inputService.Mouse2PressStarted += ToggleIsDrawingWallDestruction;
            inputService.Mouse2PressEnded += ToggleIsDrawingWallDestruction;
            builder!.OnMousePositionChanged += OnMousePositionChanged;
        }

        protected override void UnsubscribeGridBuildMethods()
        {
            IInputService inputService = GameManager.Instance.GameParameters.InputService;
            Builder builder = GameManager.Instance.Builder as Builder;

            inputService.MousePositionPerformed -= UpdateCurrentMousePosition;
            inputService.MousePositionPerformed -= DrawEvent;
            inputService.MousePositionPerformed -= DestroyEvent;
            inputService.Mouse1PressStarted -= ToggleIsDrawingWallCreation;
            inputService.Mouse1PressEnded -= ToggleIsDrawingWallCreation;
            inputService.Mouse2PressStarted -= ToggleIsDrawingWallDestruction;
            inputService.Mouse2PressEnded -= ToggleIsDrawingWallDestruction;
            builder!.OnMousePositionChanged -= OnMousePositionChanged;
        }

        protected override void OnMousePositionChanged(RaycastHit hit)
        {
            LastPosition = SnapToGrid(CurrentPosition);

            if (hit.collider != null && hit.collider.GetComponent<IBuilderItem>() != null)
                CurrentPosition = SnapToGrid(LastPosition);
            CurrentPosition = SnapToGrid(hit.point);
        }
    }
}