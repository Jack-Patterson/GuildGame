using System;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Camera
{
    public class CameraTargetController : MonoBehaviour
    {
        // private void Start()
        // {
        //     GameManager.Instance.GameParameters.InputService.MouseMoveStarted += OnMouseMove;
        // }
        //
        // private void OnMouseMove(Vector2 target)
        // {
        //     // target *= 2f;
        //
        //     Vector3 currentRotation = transform.rotation.eulerAngles;
        //     currentRotation.x -= target.y;
        //     currentRotation.y += target.x;
        //     
        //     // currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);
        //     
        //     transform.rotation = Quaternion.Euler(currentRotation);
        // }
    }
}
