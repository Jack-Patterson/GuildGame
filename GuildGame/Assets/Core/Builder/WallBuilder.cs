using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Core.Building.BuilderItem;
using com.Halcyon.API.Services.Input;
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
            if (!IsDrawingCreation ||
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

        public override void UnsubscribeGridBuildMethods()
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
            
            if (hit.collider.GetComponent<IBuilderItem>() != null)
                CurrentPosition = SnapToGrid(LastPosition);
            CurrentPosition = SnapToGrid(hit.point);
        }
    }
}