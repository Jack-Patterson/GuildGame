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
        private CameraParameters CameraParameters => GameManager.Instance.CameraParameters as CameraParameters;

        private void Awake()
        {
            GameInitializer.GameInitializationComplete += AssignCamera;
            GameInitializer.GameInitializationComplete += AssignCameraParameters;
        }

        private void AssignCamera()
        {
            GameManager.Instance.VirtualCamera = GetComponent<CinemachineFreeLook>();
        }

        private void AssignCameraParameters()
        {
            CameraParameters.TopRigCurrent = CameraParameters.RigParamsFromOrbit(Camera.m_Orbits[0]);
            CameraParameters.MiddleRigCurrent = CameraParameters.RigParamsFromOrbit(Camera.m_Orbits[1]);
            CameraParameters.BottomRigCurrent = CameraParameters.RigParamsFromOrbit(Camera.m_Orbits[2]);
        }
    }
}