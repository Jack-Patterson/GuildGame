using System;
using System.Collections.Generic;
using com.Halcyon.API.Core;
using com.Halcyon.Core.Manager;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject pointer;
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject wallPostPrefab;
        [SerializeField] private LayerMask placeRaycast;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] [HideInInspector] private List<Floor> floors = new List<Floor>();

        internal event Action BuilderGameStateEnabled;
        internal event Action BuilderGameStateDisabled;

        private const float WallGridSize = 10f;
        private WallBuilder _wallBuilder;
        private PointerHandler _pointerHandler;

        internal List<Floor> Floors
        {
            get => floors;
            set => floors = value;
        }

        private void Start()
        {
            _wallBuilder = new WallBuilder(wallPrefab, wallPostPrefab, placeRaycast, wallLayer, this);
            _pointerHandler = new PointerHandler(pointer);

            GameManager.Instance.GameParameters.InputService.ToggleBuildStarted += ToggleBuilderGameState;

            BuilderGameStateEnabled += OnBuilderGameStateEnabled;
            BuilderGameStateDisabled += OnBuilderGameStateDisabled;
        }

        private void FixedUpdate()
        {
            if (!IsInBuildMode())
                return;

            _wallBuilder.LastPosition = _wallBuilder.CurrentPosition;
            _wallBuilder.CurrentPosition = _wallBuilder.PointToPosition();
            _pointerHandler.SetPointerPosition(_wallBuilder.CurrentPosition);
        }

        internal void InstantiateBuilderPrefab(GameObject wallPrefab, Vector3 position, Quaternion rotation)
        {
            Instantiate(wallPrefab, position, rotation);
        }

        internal void GetFloors()
        {
            foreach (Transform child in transform)
            {
                Floor floor = child.GetComponent<Floor>();
                if (!floors.Contains(floor))
                    floors.Add(floor);
            }
        }

        private void ToggleBuilderGameState()
        {
            if (GameManager.Instance.GameParameters.GameState == GameState.Building)
            {
                GameLogger.Log("Disabling building mode.");

                GameManager.Instance.GameParameters.GameState = GameState.GameBase;
                BuilderGameStateDisabled?.Invoke();
            }
            else
            {
                GameLogger.Log("Enabling building mode.");

                GameManager.Instance.GameParameters.GameState = GameState.Building;
                BuilderGameStateEnabled?.Invoke();
            }
        }

        private void OnBuilderGameStateEnabled()
        {
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                _wallBuilder.UpdateCurrentMousePosition;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                _wallBuilder.DrawWall;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed +=
                _wallBuilder.DestroyWall;
            GameManager.Instance.GameParameters.InputService.Mouse1PressStarted +=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse1PressEnded +=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse2PressStarted +=
                _wallBuilder.ToggleIsDrawingWallDestruction;
            GameManager.Instance.GameParameters.InputService.Mouse2PressEnded +=
                _wallBuilder.ToggleIsDrawingWallDestruction;
        }

        private void OnBuilderGameStateDisabled()
        {
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                _wallBuilder.UpdateCurrentMousePosition;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                _wallBuilder.DrawWall;
            GameManager.Instance.GameParameters.InputService.MousePositionPerformed -=
                _wallBuilder.DestroyWall;
            GameManager.Instance.GameParameters.InputService.Mouse1PressStarted -=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse1PressEnded -=
                _wallBuilder.ToggleIsDrawingWallCreation;
            GameManager.Instance.GameParameters.InputService.Mouse2PressStarted -=
                _wallBuilder.ToggleIsDrawingWallDestruction;
            GameManager.Instance.GameParameters.InputService.Mouse2PressEnded -=
                _wallBuilder.ToggleIsDrawingWallDestruction;
        }

        private bool IsInBuildMode()
        {
            return GameManager.Instance.GameParameters.GameState == GameState.Building;
        }
    }
}