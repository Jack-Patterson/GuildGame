#nullable enable
using System;
using com.Halkyon.Services;
using com.Halkyon.Services.Logger;
using UnityEngine;

namespace com.Halkyon
{
    public class ExtendedMonoBehaviour : LoggerServiceUserMonoBehaviour
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