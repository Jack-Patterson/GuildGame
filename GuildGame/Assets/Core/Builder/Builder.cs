using System.Collections.Generic;
using com.Halcyon.API.Core.Building;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    public class Builder : BuilderAbstract
    {
        [SerializeField] [HideInInspector] private List<Floor> floors = new List<Floor>();
        
        private WallBuilderOld _wallBuilderOld;
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
            
            _wallBuilderOld = new WallBuilderOld(wallPrefab, wallPostPrefab, placeRaycast, wallLayer, this);
            _wallBuilder = new WallBuilder(placeRaycast, wallLayer);
            _pointerHandler = new PointerHandler(pointer, this);
        }

        private void FixedUpdate()
        {
            if (!IsInBuildMode())
                return;

            _wallBuilder.LastPosition = _wallBuilder.SnapToGrid(_wallBuilder.CurrentPosition);
            _wallBuilder.CurrentPosition = _wallBuilder.PointToPosition();
            print(_wallBuilder.CurrentPosition);
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
    }
}