using System;
using Cinemachine;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Camera
{
    public class CameraController : MonoBehaviour
    {
        private CinemachineFreeLook Camera => GameManager.Instance.VirtualCamera;
        private CameraParameters CameraParameter => GameManager.Instance.CameraParameters as CameraParameters;

        private void Awake()
        {
            GameInitializer.GameInitializationComplete += AssignCamera;
            GameInitializer.GameInitializationComplete += AssignCameraParameters;
            GameInitializer.GameInitializationComplete += () =>
                GameManager.Instance.GameParameters.InputService.Mouse3ScrollPerformed += ZoomCamera;
        }

        private void AssignCamera()
        {
            GameManager.Instance.VirtualCamera = GetComponent<CinemachineFreeLook>();
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
                    topNewRadius = Mathf.Clamp(CameraParameter.TopRigCurrent.Radius + 1f,
                        CameraParameter.TopRigMinimum.Radius, CameraParameter.TopRigMaximum.Radius);
                    middleNewRadius = Mathf.Clamp(CameraParameter.MiddleRigCurrent.Radius + 1f,
                        CameraParameter.MiddleRigMinimum.Radius, CameraParameter.MiddleRigMaximum.Radius);
                    bottomNewRadius = Mathf.Clamp(CameraParameter.BottomRigCurrent.Radius + 1f,
                        CameraParameter.BottomRigMinimum.Radius, CameraParameter.BottomRigMaximum.Radius);
                    break;
                case > 0:
                    topNewRadius = Mathf.Clamp(CameraParameter.TopRigCurrent.Radius - 1f,
                        CameraParameter.TopRigMinimum.Radius, CameraParameter.TopRigMaximum.Radius);
                    middleNewRadius = Mathf.Clamp(CameraParameter.MiddleRigCurrent.Radius - 1f,
                        CameraParameter.MiddleRigMinimum.Radius, CameraParameter.MiddleRigMaximum.Radius);
                    bottomNewRadius = Mathf.Clamp(CameraParameter.BottomRigCurrent.Radius - 1f,
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
    }
}