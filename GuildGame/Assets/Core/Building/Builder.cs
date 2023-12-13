using System;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Manager;
using UnityEditor;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject pointer;
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private LayerMask placeRaycast;
        [SerializeField] private LayerMask wallLayer;

        internal const float WallGridSize = 10f;

        private WallSnapping _wallSnapping;
        private PointerHandler _pointerHandler;

        private void Start()
        {
            _wallSnapping = new WallSnapping(wallPrefab, placeRaycast, wallLayer);
            _pointerHandler = new PointerHandler(pointer);
        }

        private void Update()
        {
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     GameManager.Instance.GameParameters.GameState =
            //         GameManager.Instance.GameParameters.GameState == GameState.GameBase
            //             ? GameState.Building
            //             : GameState.GameBase;
            // }

            if (!IsInBuildMode())
                return;

            // if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            // {
            //     _wallSnapping.ToggleIsDrawingWall();
            // }

            if (!Utils.ValidateVectorSameAsAnother(_wallSnapping.CurrentPosition, _wallSnapping.LastPosition))
            {
                if (_wallSnapping.IsDrawing)
                {
                    Vector3 instantiationPoint = (_wallSnapping.CurrentPosition + _wallSnapping.LastPosition) / 2;

                    Collider[] colliders = Physics.OverlapSphere(
                        new Vector3(instantiationPoint.x, instantiationPoint.y + 2f, instantiationPoint.z), 1f,
                        wallLayer);

                    bool shouldInstantiateWall = !CheckColliderArrayContainsScript<WallScript>(colliders);
                    bool wallPositionValid = _wallSnapping.ValidateWallPlacePosition(instantiationPoint);

                    if (shouldInstantiateWall && wallPositionValid)
                    {
                        Debug.Log(
                            $"Point {_wallSnapping.CurrentPosition} Last Point {_wallSnapping.LastPosition} Instatitation Point {instantiationPoint}");
                        bool shouldRotatePrefab = Math.Abs(instantiationPoint.x) != Math.Abs(_wallSnapping.CurrentPosition.x);
                        Quaternion rotation = Quaternion.Euler(0, shouldRotatePrefab ? 0 : 90, 0);

                        Instantiate(wallPrefab, instantiationPoint, rotation);
                    }
                }

                _wallSnapping.LastPosition = _wallSnapping.CurrentPosition;
            }
        }

        private void FixedUpdate()
        {
            if (!IsInBuildMode())
                return;

            // _wallSnapping.CurrentPosition = _wallSnapping.PointToPosition();
            _pointerHandler.SetPointerPosition(_wallSnapping.CurrentPosition);
        }

        private bool IsInBuildMode()
        {
            return GameManager.Instance.GameParameters.GameState == GameState.Building;
        }

        private bool CheckColliderArrayContainsScript<T>(Collider[] colliders)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<T>() != null)
                {
                    return true;
                }
            }

            return false;
        }

        [CustomEditor(typeof(Builder))]
        public class BuilderEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                Builder gridLines = (Builder)target;

                if (GUILayout.Button("Generate Grid"))
                {
                    // gridLines.CreateGrid();
                }

                if (GUILayout.Button("Remove Grid"))
                {
                    // gridLines.ClearGrid();
                }

                Color c = EditorGUILayout.ColorField("Color", Color.white, new GUILayoutOption[] { });
            }
        }
    }
}