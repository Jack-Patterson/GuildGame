using System;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class WallPlacement: MonoBehaviour
    {
        [SerializeField] private GameObject wallPrefab;
        private float gridSize = 10f;

        private GameObject currentWall;
        private bool isDragging;

        private Vector3 lastMousePosition;
        private void Update()
        {
            // return;
            // HandleInput();
            // DrawGrid();
            // if (Input.GetMouseButton(0))
            // {
            //     Vector3 mousePosition = GetMouseWorldPosition();
            //     Vector3 snappedPosition = SnapToGrid(mousePosition);
            //
            //     // Check if the mouse has moved to a new grid position
            //     if (snappedPosition != lastMousePosition)
            //     {
            //         print((snappedPosition, mousePosition, lastMousePosition));
            //         DrawWall(snappedPosition, mousePosition-lastMousePosition);
            //         lastMousePosition = snappedPosition;
            //     }
            // }
        }
        
        private Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        private Vector3 SnapToGrid(Vector3 position)
        {
            float x = Mathf.Round(position.x / gridSize) * gridSize;
            float y = Mathf.Round(position.y / gridSize) * gridSize;
            float z = Mathf.Round(position.z / gridSize) * gridSize;

            return new Vector3(x, y, z);
        }

        private void DrawWall(Vector3 position, Vector3 direction)
        {
            print(direction);
            // Calculate the angle of the mouse movement in degrees
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            // Quantize the angle to multiples of 90 degrees
            float quantizedAngle = Mathf.Round(angle / 90.0f) * 90.0f;

            // Set the rotation to only rotate on the y-axis and in 90-degree angles
            Quaternion rotation = Quaternion.Euler(0f, quantizedAngle, 0f);

            position = FixPosition(position, quantizedAngle);

            // Instantiate the wall prefab with the calculated rotation
            Instantiate(wallPrefab, position, rotation);
        }

        private Vector3 FixPosition(Vector3 proposedPosition, float quantizedAngle)
        {
            if (Math.Abs(quantizedAngle) == 90 || Math.Abs(quantizedAngle) == 270)
                return new Vector3(proposedPosition.x, proposedPosition.y, proposedPosition.z - 5);
            else 
                return new Vector3(proposedPosition.x+5, proposedPosition.y, proposedPosition.z);
        }
        
        private void OnDrawGizmos()
        {
            DrawGrid();
        }

        private void DrawGrid()
        {
            Vector3 center = transform.position; // Use the object's position as the center of the grid

            // Draw grid lines along the X axis
            for (float x = center.x - 50f; x <= center.x + 50f; x += gridSize)
            {
                DrawGridLine(new Vector3(x, center.y, center.z - 50f), new Vector3(x, center.y, center.z + 50f));
            }

            // Draw grid lines along the Z axis
            for (float z = center.z - 50f; z <= center.z + 50f; z += gridSize)
            {
                DrawGridLine(new Vector3(center.x - 50f, center.y, z), new Vector3(center.x + 50f, center.y, z));
            }
        }

        private void DrawGridLine(Vector3 start, Vector3 end)
        {
            Debug.DrawLine(start, end, Color.white);
        }

        // private void HandleInput()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         StartPlacingWall();
        //     }
        //     
        //     if (Input.GetMouseButtonUp(0))
        //     {
        //         StopPlacingWall();
        //     }
        //     
        //     if (isDragging)
        //     {
        //         UpdateWallPosition();
        //     }
        // }
        //
        // void StartPlacingWall()
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         Vector2 gridPosition = SnapToGrid(hit.point, hit.normal);
        //
        //         currentWall = Instantiate(wallPrefab, gridPosition, Quaternion.identity);
        //         isDragging = true;
        //     }
        // }
        //
        // void StopPlacingWall()
        // {
        //     isDragging = false;
        //     currentWall = null;
        // }
        //
        // void UpdateWallPosition()
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         Vector2 gridPosition = SnapToGrid(hit.point, hit.normal);
        //         currentWall.transform.position = gridPosition;
        //     }
        // }
        //
        // Vector2 SnapToGrid(Vector3 position, Vector3 normal)
        // {
        //     // Use the normal to determine the orientation of the grid
        //     Vector3 right = Vector3.Cross(Vector3.up, normal).normalized;
        //
        //     // Project the position onto the plane defined by the normal
        //     Vector3 projectedPosition = Vector3.ProjectOnPlane(position, normal);
        //
        //     // Calculate grid coordinates based on the projected position and orientation
        //     float x = Mathf.Floor((projectedPosition.x - transform.position.x) / gridSize) * gridSize + gridSize / 2f;
        //     float y = Mathf.Floor((projectedPosition.y - transform.position.y) / gridSize) * gridSize + gridSize / 2f;
        //
        //     // Transform back to world coordinates
        //     Vector3 snappedPosition = transform.position + right * x + Vector3.up * y;
        //
        //     return new Vector2(snappedPosition.x, snappedPosition.y);
        // }
    }
}