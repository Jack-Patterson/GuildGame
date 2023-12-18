using Cinemachine;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.Core.Manager;

namespace com.Halcyon.Core.Camera
{
    public class CameraParameters : ICameraParameters
    {
        public RigParameters TopRigMinimum => new RigParameters(15f, 1f);
        public RigParameters MiddleRigMinimum => new RigParameters(8f, 7f);
        public RigParameters BottomRigMinimum => new RigParameters(1f, 7f);

        public RigParameters TopRigMaximum => new RigParameters(15f, 51f);
        public RigParameters MiddleRigMaximum => new RigParameters(8f, 57f);
        public RigParameters BottomRigMaximum => new RigParameters(1f, 57f);

        public RigParameters TopRigCurrent
        {
            get => RigParamsFromOrbit(GameManager.Instance.VirtualCamera.m_Orbits[0]);
            set => GameManager.Instance.VirtualCamera.m_Orbits[0] = RigParamsToOrbit(value);
        }

        public RigParameters MiddleRigCurrent
        {
            get => RigParamsFromOrbit(GameManager.Instance.VirtualCamera.m_Orbits[1]);
            set => GameManager.Instance.VirtualCamera.m_Orbits[1] = RigParamsToOrbit(value);
        }

        public RigParameters BottomRigCurrent
        {
            get => RigParamsFromOrbit(GameManager.Instance.VirtualCamera.m_Orbits[2]);
            set => GameManager.Instance.VirtualCamera.m_Orbits[2] = RigParamsToOrbit(value);
        }

        public CameraParameters()
        {
        }

        public static RigParameters RigParamsFromOrbit(CinemachineFreeLook.Orbit orbit) =>
            new RigParameters(orbit.m_Height, orbit.m_Radius);

        public static CinemachineFreeLook.Orbit RigParamsToOrbit(RigParameters rigParameters) =>
            new CinemachineFreeLook.Orbit(rigParameters.Height, rigParameters.Radius);
    }
}