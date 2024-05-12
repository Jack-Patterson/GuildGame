using Cinemachine;
using com.Halcyon.API.Core.Camera;
using com.Halcyon.API.Services.Serialization;
using com.Halcyon.Core.Manager;

namespace com.Halcyon.Core.Camera
{
    public class CameraParameters : ICameraParameters
    {
        public RigParameters TopRigMinimum => new RigParameters(40f, 1f);
        public RigParameters MiddleRigMinimum => new RigParameters(12f, 7f);
        public RigParameters BottomRigMinimum => new RigParameters(5f, 9f);

        public RigParameters TopRigMaximum => new RigParameters(40f, 51f);
        public RigParameters MiddleRigMaximum => new RigParameters(12f, 57f);
        public RigParameters BottomRigMaximum => new RigParameters(5f, 57f);

        private float _moveSpeed = 5f;
        private float _zoomSpeed = 1f;

        private SerializableVector2 _cameraBoundsPositive = new SerializableVector2(50f, 50f);
        private SerializableVector2 _cameraBoundsNegative = new SerializableVector2(-50f, -50f);

        public float MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }

        public float ZoomSpeed
        {
            get => _zoomSpeed;
            set => _zoomSpeed = value;
        }

        public SerializableVector2 CameraBoundsPositive
        {
            get => _cameraBoundsPositive;
            set => _cameraBoundsPositive = value;
        }

        public SerializableVector2 CameraBoundsNegative
        {
            get => _cameraBoundsNegative;
            set => _cameraBoundsNegative = value;
        }

        public RigParameters TopRigCurrent
        {
            get => RigParamsFromOrbit(GameManager.Instance.Camera.m_Orbits[0]);
            set => GameManager.Instance.Camera.m_Orbits[0] = RigParamsToOrbit(value);
        }

        public RigParameters MiddleRigCurrent
        {
            get => RigParamsFromOrbit(GameManager.Instance.Camera.m_Orbits[1]);
            set => GameManager.Instance.Camera.m_Orbits[1] = RigParamsToOrbit(value);
        }

        public RigParameters BottomRigCurrent
        {
            get => RigParamsFromOrbit(GameManager.Instance.Camera.m_Orbits[2]);
            set => GameManager.Instance.Camera.m_Orbits[2] = RigParamsToOrbit(value);
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