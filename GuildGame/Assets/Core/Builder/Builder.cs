﻿using System;
using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.Core.Builder.FloorBuilder;
using com.Halcyon.Core.Builder.GridBuilder;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    public class Builder : BuilderAbstract
    {
        private WallBuilder _wallBuilder;
        private PointerHandler _pointerHandler;
        
        internal Action<RaycastHit> OnMousePositionChanged;

        protected override void OnStart()
        {
            base.OnStart();
            
            List<Floor> floors = Utils.GetComponentsFromTransform<Floor>(transform);
            
            _wallBuilder = new WallBuilder(placeRaycast, wallLayer);
            _pointerHandler = new PointerHandler(pointer, this);
            _floorHandler = new FloorHandler(floors);
            
            InvokeOnBuilderInitialisationComplete();
            _floorHandler.InvokeFloorChanged(1);
        }

        private void FixedUpdate()
        {
            if (!IsInBuildMode)
                return;
            
            _pointerHandler.Position = _wallBuilder.CurrentPosition;
        }

        internal List<GameObject> GetPrefabs(GridBuilderBase gridBuilder)
        {
            switch (gridBuilder)
            {
                case WallBuilder:
                    return new List<GameObject> { wallPrefab, wallPostPrefab };
            }

            return null;
        }
        
        protected override void UpdateCurrentMousePosition(Vector2 value)
        {
            if (value == CurrentMousePosition)
                return;
            
            CurrentMousePosition = value;

            RaycastHit worldPosition = MousePositionToWorldPosition();
            OnMousePositionChanged?.Invoke(worldPosition);
        }

        protected override void SubscribeBuilderMethods()
        {
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                UpdateCurrentMousePosition;
        }
        
        protected override void UnsubscribeBuilderMethods()
        {
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                UpdateCurrentMousePosition;
        }
    }
}