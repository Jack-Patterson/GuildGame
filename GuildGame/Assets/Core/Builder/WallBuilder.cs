﻿using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal class WallBuilder: GridBuilderBase
    {
        public WallBuilder(LayerMask placeRaycast, LayerMask wallLayer) : base(placeRaycast, wallLayer)
        {
        }

        public WallBuilder(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer) : base(wallGridSize, placeRaycast, wallLayer)
        {
        }

        protected override void Draw(Builder builder, List<GameObject> prefabToUse)
        {
            if (!IsDrawingCreation || !IsBuildModeEnabled ||
                Utils.ValidateVectorSameAsAnother(CurrentPosition, LastPosition))
                return;
            
            GameLogger.Log((prefabToUse.Count, prefabToUse[0], prefabToUse[1]));
        }

        protected override void Create(Builder builder, List<GameObject> prefabToUse)
        {
            throw new System.NotImplementedException();
        }

        protected override void Destroy(Builder builder)
        {
            if (!IsDrawingDestruction || !IsBuildModeEnabled)
                return;
            
            GameLogger.Log("destroying");
        }

        public override void SubscribeGridBuildMethods()
        {
            GameLogger.Log("Enabled");
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                UpdateCurrentMousePosition;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                DrawEvent;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                DestroyEvent;
            GameManager.Instance.GameParameters.InputService.Mouse1PressStarted +=
                ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse1PressEnded +=
                ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse2PressStarted +=
                ToggleIsDrawingWallDestruction;
            GameManager.Instance.GameParameters.InputService.Mouse2PressEnded +=
                ToggleIsDrawingWallDestruction;
        }
    }
}