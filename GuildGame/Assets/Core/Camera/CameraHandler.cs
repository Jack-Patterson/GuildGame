using Cinemachine;
using com.Halcyon.API.Core;
using com.Halcyon.API.Core.Building;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Camera
{
    public class CameraHandler : ExtendedMonoBehaviour
    {
        private CinemachineFreeLook Camera => GameManager.Instance.Camera;
        private UnityEngine.Camera UnityEngineCamera => UnityEngine.Camera.main;
        private CameraParameters CameraParameter => GameManager.Instance.CameraParameters as CameraParameters;
        private Vector2 _moveDirection = Vector2.zero;

        protected override void OnAwake()
        {
            GameInitializer.GameInitializationComplete += AssignCamera;
            GameInitializer.GameInitializationComplete += AssignCameraParameters;
            GameInitializer.GameInitializationComplete += () =>
            {
                GameManager.Instance.GameParameters.InputService.Mouse3ScrollPerformed += ZoomCamera;
                GameManager.Instance.GameParameters.InputService.MovePerformed += UpdateMoveDirection;
                BuilderAbstract.BuilderInitialisationCompleted += () =>
                    GameManager.Instance.Builder.FloorHandler.OnFloorChanged += OnFloorChanged;
            };
        }

        protected override void OnUpdate()
        {
            if (_moveDirection != Vector2.zero)
            {
                MoveCamera();
            }
        }

        private void AssignCamera()
        {
            GameManager.Instance.Camera = GetComponent<CinemachineFreeLook>();
        }

        private void AssignCameraParameters()
        {
            CameraParameter.TopRigCurrent = CameraParameters.RigParamsFromOrbit(Camera.m_Orbits[0]);
            CameraParameter.MiddleRigCurrent = CameraParameters.RigParamsFromOrbit(Camera.m_Orbits[1]);
            CameraParameter.BottomRigCurrent = CameraParameters.RigParamsFromOrbit(Camera.m_Orbits[2]);
        }

        private void ZoomCamera(float value)
        {
            float topNewRadius, middleNewRadius, bottomNewRadius;

            switch (value)
            {
                case < 0:
                    topNewRadius = Mathf.Clamp(CameraParameter.TopRigCurrent.Radius + CameraParameter.ZoomSpeed,
                        CameraParameter.TopRigMinimum.Radius, CameraParameter.TopRigMaximum.Radius);
                    middleNewRadius = Mathf.Clamp(CameraParameter.MiddleRigCurrent.Radius + CameraParameter.ZoomSpeed,
                        CameraParameter.MiddleRigMinimum.Radius, CameraParameter.MiddleRigMaximum.Radius);
                    bottomNewRadius = Mathf.Clamp(CameraParameter.BottomRigCurrent.Radius + CameraParameter.ZoomSpeed,
                        CameraParameter.BottomRigMinimum.Radius, CameraParameter.BottomRigMaximum.Radius);
                    break;
                case > 0:
                    topNewRadius = Mathf.Clamp(CameraParameter.TopRigCurrent.Radius - CameraParameter.ZoomSpeed,
                        CameraParameter.TopRigMinimum.Radius, CameraParameter.TopRigMaximum.Radius);
                    middleNewRadius = Mathf.Clamp(CameraParameter.MiddleRigCurrent.Radius - CameraParameter.ZoomSpeed,
                        CameraParameter.MiddleRigMinimum.Radius, CameraParameter.MiddleRigMaximum.Radius);
                    bottomNewRadius = Mathf.Clamp(CameraParameter.BottomRigCurrent.Radius - CameraParameter.ZoomSpeed,
                        CameraParameter.BottomRigMinimum.Radius, CameraParameter.BottomRigMaximum.Radius);
                    break;
                default:
                    return;
            }

            CameraParameter.TopRigCurrent = new RigParameters(CameraParameter.TopRigCurrent.Height, topNewRadius);
            CameraParameter.MiddleRigCurrent =
                new RigParameters(CameraParameter.MiddleRigCurrent.Height, middleNewRadius);
            CameraParameter.BottomRigCurrent =
                new RigParameters(CameraParameter.BottomRigCurrent.Height, bottomNewRadius);
        }

        private void MoveCamera()
        {
            float moveDirectionX, moveDirectionZ;

            if (_moveDirection.x > 0) moveDirectionX = 1f;
            else if (_moveDirection.x < 0) moveDirectionX = -1f;
            else moveDirectionX = 0f;

            if (_moveDirection.y > 0) moveDirectionZ = 1f;
            else if (_moveDirection.y < 0) moveDirectionZ = -1f;
            else moveDirectionZ = 0f;

            Transform mainCamera = UnityEngineCamera.transform;
            Vector3 movement = mainCamera.forward * moveDirectionZ + mainCamera.right * moveDirectionX;
            movement.y = 0f;
            movement.Normalize();

            Camera.Follow.Translate(movement * (CameraParameter.MoveSpeed * Time.deltaTime));
        }

        private void OnFloorChanged(int newFloorIndex)
        {
            Vector3 position = Camera.Follow.position;
            position.y = (int)((newFloorIndex - 1) * Constants.BuilderConstants.FloorHeight);

            Camera.Follow.position = position;
        }

        private void UpdateMoveDirection(Vector2 value)
        {
            _moveDirection = value;
        }
    }
}