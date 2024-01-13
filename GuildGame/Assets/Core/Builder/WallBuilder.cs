#nullable enable

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

        protected override void Draw(Transform parent, List<GameObject> prefabsToUse)
        {
            float rotationAngleTrue = 0f;
            float rotationAngleFalse = 90f;

            Vector3 expectedWallPosition = (CurrentPosition + LastPosition) / 2;
            expectedWallPosition.y += Constants.FloorHeight / 2;

            WallBuildItem potentialExistingWall =
                Utils.OverlapAreaGetItem<WallBuildItem>(expectedWallPosition, Constants.WallCheckRadius, WallLayer);
            bool shouldInstantiateWall = potentialExistingWall == null;
            bool wallPositionValid = ValidateWallPlacePosition(expectedWallPosition);

            float absoluteInstantiationX = Math.Abs(expectedWallPosition.x);
            float absoluteCurrentX = Math.Abs(CurrentPosition.x);
            bool shouldRotatePrefab = !absoluteInstantiationX.Equals(absoluteCurrentX);
            float rotationYAngle = shouldRotatePrefab ? rotationAngleTrue : rotationAngleFalse;
            Quaternion rotation = Quaternion.Euler(0f, rotationYAngle, 0f);

            GameObject wallPrefabToUse = Utils.GetPrefabFromListByScript<WallBuildItem>(prefabsToUse)!;
            GameObject postPrefabToUse = Utils.GetPrefabFromListByScript<WallPostBuildItem>(prefabsToUse)!;

            if (IsDrawingCreation && shouldInstantiateWall && wallPositionValid)
            {
                if (wallPrefabToUse == null)
                {
                    GameLogger.Log("No prefab found which is a WallBuildItem.", LogType.Error);
                    return;
                }
                
                if (postPrefabToUse == null)
                {
                    GameLogger.Log("No prefab found which is a WallPostBuildItem.", LogType.Error);
                    return;
                }

                Create(parent, wallPrefabToUse, expectedWallPosition, rotation);
            }
            else if (IsDrawingDestruction && !shouldInstantiateWall && wallPositionValid)
            {
                Destroy(potentialExistingWall!.gameObject);
            }

            DrawPosts(expectedWallPosition, rotation, postPrefabToUse, parent);
        }

        private void DrawPosts(Vector3 wallPosition, Quaternion rotation, GameObject wallPostPrefab,
            Transform parent)
        {
            WallPostBuildItem firstPotentialPost, secondPotentialPost;
            int firstPostOverlapItemsAmount, secondPostOverlapItemsAmount;
            bool wallIsRotated = rotation.eulerAngles.y.Equals(90f);
            float distance = WallGridSize / 2;

            Vector3 firstPossiblePostPosition = !wallIsRotated
                ? new Vector3(wallPosition.x + distance, wallPosition.y, wallPosition.z)
                : new Vector3(wallPosition.x, wallPosition.y, wallPosition.z + distance);
            Vector3 secondPossiblePostPosition = !wallIsRotated
                ? new Vector3(wallPosition.x - distance, wallPosition.y, wallPosition.z)
                : new Vector3(wallPosition.x, wallPosition.y, wallPosition.z - distance);
            
            (firstPotentialPost, firstPostOverlapItemsAmount) =
                Utils.OverlapAreaGetItemAndCheckForAnotherType<WallPostBuildItem>(firstPossiblePostPosition,
                    Constants.WallCheckRadius, WallLayer, typeof(WallBuildItem));
            (secondPotentialPost, secondPostOverlapItemsAmount) =
                Utils.OverlapAreaGetItemAndCheckForAnotherType<WallPostBuildItem>(secondPossiblePostPosition,
                    Constants.WallCheckRadius, WallLayer, typeof(WallBuildItem));
            
            bool firstPostIsNull = firstPotentialPost == null;
            bool secondPostIsNull = secondPotentialPost == null;

            if (IsDrawingCreation)
            {
                if (firstPostIsNull)
                {
                    Create(parent, wallPostPrefab, firstPossiblePostPosition, rotation);
                }
                if (secondPostIsNull)
                {
                    Create(parent, wallPostPrefab, secondPossiblePostPosition, rotation);
                }
            }
            else if (IsDrawingDestruction)
            {
                if (!firstPostIsNull && firstPostOverlapItemsAmount == 1)
                {
                    Destroy(firstPotentialPost!.gameObject);
                }

                if (!secondPostIsNull && secondPostOverlapItemsAmount == 1)
                {
                    Destroy(secondPotentialPost!.gameObject);
                }
            }
        }

        private bool ValidateWallPlacePosition(Vector3 vector)
        {
            int xMod5 = (int)vector.x % 5;
            int zMod5 = (int)vector.z % 5;
            int xMod10 = (int)vector.x % 10;
            int zMod10 = (int)vector.z % 10;

            bool validNumbers = (xMod5 == 0 && zMod10 == 0) || (xMod10 == 0 && zMod5 == 0);

            bool isValid = validNumbers && (Mathf.Abs((int)vector.x) % 10 == 5 || Mathf.Abs((int)vector.z) % 10 == 5);

            return isValid;
        }

        protected override void SubscribeGridBuildMethods()
        {
            IInputService inputService = GameManager.Instance.GameParameters.InputService;
            Builder builder = (GameManager.Instance.Builder as Builder)!;

            inputService.MousePositionPerformed += UpdateCurrentMousePosition;
            inputService.MousePositionPerformed += DrawEvent;
            inputService.Mouse1PressStarted += ToggleIsDrawingWallCreation;
            inputService.Mouse1PressEnded += ToggleIsDrawingWallCreation;
            inputService.Mouse2PressStarted += ToggleIsDrawingWallDestruction;
            inputService.Mouse2PressEnded += ToggleIsDrawingWallDestruction;
            builder.OnMousePositionChanged += OnMousePositionChanged;
        }

        protected override void UnsubscribeGridBuildMethods()
        {
            IInputService inputService = GameManager.Instance.GameParameters.InputService;
            Builder builder = (GameManager.Instance.Builder as Builder)!;

            inputService.MousePositionPerformed -= UpdateCurrentMousePosition;
            inputService.MousePositionPerformed -= DrawEvent;
            inputService.Mouse1PressStarted -= ToggleIsDrawingWallCreation;
            inputService.Mouse1PressEnded -= ToggleIsDrawingWallCreation;
            inputService.Mouse2PressStarted -= ToggleIsDrawingWallDestruction;
            inputService.Mouse2PressEnded -= ToggleIsDrawingWallDestruction;
            builder.OnMousePositionChanged -= OnMousePositionChanged;
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