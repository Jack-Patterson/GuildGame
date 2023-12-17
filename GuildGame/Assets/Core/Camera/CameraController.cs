using System;
using Cinemachine;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Camera
{
    public class CameraController : MonoBehaviour
    {
        // [SerializeField] private CinemachineInputProvider inputProvider;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private float scrollBorderPercent = 0.05f;

        [SerializeField] private float panSpeed = 50.0f;

        // [SerializeField] private float zoomSpeed = 5.0f;
        private CinemachineVirtualCamera Camera => GameManager.Instance.VirtualCamera;

        private float _currentZoom;
        private float _rotationSpeed = 2.0f;
        private float _zoomSpeed = 2.0f;
        private float _minZoom = 5.0f;
        private float _maxZoom = 20.0f;

        private void Awake()
        {
            GameInitializer.GameInitializationComplete += AssignCamera;
        }

        private void Start()
        {
            _currentZoom = Camera.m_Lens.OrthographicSize;
            // GameManager.Instance.GameParameters.InputService.MouseMoveStarted += PanCamera;
        }

        private void PanCamera(Vector2 movement)
        {
            float minVerticalAngle = -80f; // Minimum vertical rotation angle
            float maxVerticalAngle = 80f;
            
            print("Enetered" + movement);
            // transform.RotateAround(targetTransform.position, Vector3.up, movement.x * _rotationSpeed);
            
            float rotationX = -movement.y * _rotationSpeed;
            float rotationY = movement.x * _rotationSpeed;
            
            float currentXRotation = transform.eulerAngles.x;
            print(currentXRotation);
            print(currentXRotation + rotationX);
            
            
            // float clampedXRotation = Mathf.Clamp(currentXRotation + rotationX, minVerticalAngle, maxVerticalAngle);
            float clampedXRotation = Mathf.Clamp((currentXRotation + rotationX), minVerticalAngle, maxVerticalAngle);
            print(clampedXRotation);
            
            transform.RotateAround(targetTransform.position, Vector3.up, rotationY);
            
            // transform.rotation = Quaternion.Euler(clampedXRotation, transform.eulerAngles.y, 0f);
            transform.RotateAround(targetTransform.position, Vector3.right, clampedXRotation);
            // transform.RotateAround(targetTransform.position, transform.right, clampedXRotation-currentXRotation);
        }

        private void Update()
        {
            // transform.LookAt(targetTransform);
        }

        // private void PanScreenInDirection(Vector2 direction)
        // {
        //     Vector3 panDirection = Vector3.zero;
        //
        //     if (direction.y >= Screen.height * (1 - scrollBorderPercent))
        //     {
        //         panDirection.z += 1;
        //     }
        //     else if (direction.y <= Screen.height * scrollBorderPercent)
        //     {
        //         panDirection.z -= 1;
        //     }
        //
        //     if (direction.x >= Screen.width * (1 - scrollBorderPercent))
        //     {
        //         panDirection.x += 1;
        //     }
        //     else if (direction.x <= Screen.width * scrollBorderPercent)
        //     {
        //         panDirection.x -= 1;
        //     }
        //
        //     cameraTransform.position = Vector3.Lerp(cameraTransform.position,
        //         cameraTransform.position + panDirection * panSpeed, Time.deltaTime);
        // }

        private void AssignCamera()
        {
            GameManager.Instance.VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
    }
}