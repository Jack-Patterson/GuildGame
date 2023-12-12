using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class WallSnapping
    {
        private GameObject wallPrefab;
        private LayerMask placeRaycast;
        private LayerMask wallLayer;

        private Vector3 _currentPosition = Vector3.zero;
        private Vector3 _lastPosition = Vector3.zero;
        private bool _isDrawing = false;

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
        
        public bool IsDrawing
        {
            get => _isDrawing;
            set => _isDrawing = value;
        }

        public WallSnapping(GameObject wallPrefab, LayerMask placeRaycast, LayerMask wallLayer)
        {
            this.wallPrefab = wallPrefab;
            this.placeRaycast = placeRaycast;
            this.wallLayer = wallLayer;
        }

        internal bool ValidateWallPlacePosition(Vector3 vector)
        {
            int xMod5 = (int)vector.x % 5;
            int zMod5 = (int)vector.z % 5;
            int xMod10 = (int)vector.x % 10;
            int zMod10 = (int)vector.z % 10;

            return (xMod5 == 0 && zMod10 == 0) || (xMod10 == 0 && zMod5 == 0);
        }

        internal Vector3 PointToPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, placeRaycast))
            {
                return SnapToGrid(hit.point);
            }

            return SnapToGrid(_lastPosition);
        }

        internal void ToggleIsDrawingWall()
        {
            _isDrawing = !_isDrawing;
        }

        private Vector3 SnapToGrid(Vector3 position)
        {
            float x = Mathf.Round(position.x / Builder.WallGridSize) * Builder.WallGridSize;
            float z = Mathf.Round(position.z / Builder.WallGridSize) * Builder.WallGridSize;

            return new Vector3(x, position.y, z);
        }
    }
}