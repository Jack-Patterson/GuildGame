using System;
using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class Builder : BuilderAbstract
    {
        [SerializeField] [HideInInspector] private List<Floor> floors = new List<Floor>();
        
        private WallBuilder _wallBuilder;
        private PointerHandler _pointerHandler;

        internal List<Floor> Floors
        {
            get => floors;
            set => floors = value;
        }

        private new void Start()
        {
            base.Start();
            
            _wallBuilder = new WallBuilder(wallPrefab, wallPostPrefab, placeRaycast, wallLayer, this);
            _pointerHandler = new PointerHandler(pointer);
        }

        private void FixedUpdate()
        {
            if (!IsInBuildMode())
                return;

            _wallBuilder.LastPosition = _wallBuilder.CurrentPosition;
            _wallBuilder.CurrentPosition = _wallBuilder.PointToPosition();
            _pointerHandler.SetPointerPosition(_wallBuilder.CurrentPosition);
        }

        public bool SaveAction(string relativeLocation)
        {
            return GameManager.Instance.GameParameters.JsonSerializationService.SaveData(
                SerializableBuilderItem.GetBuilderItemsFromInterfaceList(BuilderItems), relativeLocation);
        }

        public T LoadAction<T>(string relativeLocation)
        {
            return GameManager.Instance.GameParameters.JsonSerializationService.LoadData<T>(relativeLocation);
        }

        internal void GetFloors()
        {
            foreach (Transform child in transform)
            {
                Floor floor = child.GetComponent<Floor>();
                if (!floors.Contains(floor))
                    floors.Add(floor);
            }
        }

        protected override void OnBuilderGameStateEnabled()
        {
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                _wallBuilder.UpdateCurrentMousePosition;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                _wallBuilder.DrawWall;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                _wallBuilder.DestroyWall;
            GameManager.Instance.GameParameters.InputService.Mouse1PressStarted +=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse1PressEnded +=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse2PressStarted +=
                _wallBuilder.ToggleIsDrawingWallDestruction;
            GameManager.Instance.GameParameters.InputService.Mouse2PressEnded +=
                _wallBuilder.ToggleIsDrawingWallDestruction;
        }

        protected override void OnBuilderGameStateDisabled()
        {
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                _wallBuilder.UpdateCurrentMousePosition;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                _wallBuilder.DrawWall;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                _wallBuilder.DestroyWall;
            GameManager.Instance.GameParameters.InputService.Mouse1PressStarted -=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse1PressEnded -=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse2PressStarted -=
                _wallBuilder.ToggleIsDrawingWallDestruction;
            GameManager.Instance.GameParameters.InputService.Mouse2PressEnded -=
                _wallBuilder.ToggleIsDrawingWallDestruction;
        }
    }
}