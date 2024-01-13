using System;
using System.Collections.Generic;
using com.Halcyon.API.Core.Building;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    public class Builder : BuilderAbstract
    {
        [SerializeField] [HideInInspector] private List<Floor> floors = new List<Floor>();

        private WallBuilder _wallBuilder;
        private PointerHandler _pointerHandler;
        
        internal Action<RaycastHit> OnMousePositionChanged;

        internal List<Floor> Floors
        {
            get => floors;
            set => floors = value;
        }

        private new void Start()
        {
            base.Start();
            
            _wallBuilder = new WallBuilder(placeRaycast, wallLayer);
            _pointerHandler = new PointerHandler(pointer, this);
        }

        private void FixedUpdate()
        {
            if (!IsInBuildMode)
                return;
            
            _pointerHandler.Position = _wallBuilder.CurrentPosition;
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