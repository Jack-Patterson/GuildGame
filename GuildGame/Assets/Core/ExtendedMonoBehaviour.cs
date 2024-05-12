using UnityEngine;

namespace com.Halkyon
{
    public class ExtendedMonoBehaviour : MonoBehaviour
    {
        public GameManager GameManager => GameManager.Instance;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }
    }
}