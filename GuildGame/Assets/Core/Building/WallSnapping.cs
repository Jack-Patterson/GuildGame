using System;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class WallSnapping : MonoBehaviour
    {
        [SerializeField] private GameObject pointer;
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private LayerMask placeRaycast;
        [SerializeField] private LayerMask wallLayer;
        private Vector3 _lastPosition = Vector3.zero;
        private float _gridSize = 10f;
        private bool isDrawing = false;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                isDrawing = !isDrawing;
            }

            Vector3 point = PointToPosition();
            point = SnapToGrid(point);
            pointer.transform.position = point;
            print((point, isDrawing));

            if (isDrawing && _lastPosition != point)
            {
                Vector3 instantiationPoint = (point + _lastPosition) / 2;

                Collider[] colliders = Physics.OverlapSphere(new Vector3(instantiationPoint.x,
                    instantiationPoint.y + 2f, instantiationPoint.z), 1f, wallLayer);


                bool skipInstantiation = false;
                foreach (Collider collider in colliders)
                {
                    if (collider.GetComponent<WallScript>())
                    {
                        skipInstantiation = true;
                    }
                }
                
                if (!skipInstantiation && CheckVector3Conditions(instantiationPoint))
                {
                    print($"Point {point} Last Point {_lastPosition} Instatitation Point {instantiationPoint}");
                    bool shouldRotatePrefab = Math.Abs(instantiationPoint.x) != Math.Abs(point.x);
                    Quaternion rotation =
                        shouldRotatePrefab ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(0, 90, 0);

                    Instantiate(wallPrefab, instantiationPoint, rotation);
                }

                _lastPosition = point;
            }
            else if (_lastPosition != point)
            {
                _lastPosition = point;
            }
        }
        
        private bool CheckVector3Conditions(Vector3 vector)
        {
            int xMod5 = (int)vector.x % 5;
            int zMod5 = (int)vector.z % 5;
            int xMod10 = (int)vector.x % 10;
            int zMod10 = (int)vector.z % 10;

            return (xMod5 == 0 && zMod10 == 0) || (xMod10 == 0 && zMod5 == 0);
        }

        private Vector3 PointToPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, placeRaycast))
            {
                return hit.point;
            }

            return _lastPosition;
        }

        private Vector3 SnapToGrid(Vector3 position)
        {
            float x = Mathf.Round(position.x / _gridSize) * _gridSize;
            float z = Mathf.Round(position.z / _gridSize) * _gridSize;

            return new Vector3(x, position.y, z);
        }
    }
}