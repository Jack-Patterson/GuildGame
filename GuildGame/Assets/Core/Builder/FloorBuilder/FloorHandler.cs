using System;
using System.Collections.Generic;
using com.Halcyon.API.Core.Building;

namespace com.Halcyon.Core.Builder.FloorBuilder
{
    public class FloorHandler : BuilderSubscriberItem, IFloorHandler
    {
        private int _currentFloor = 1;
        public List<Floor> Floors { get; }

        public event Action<int> OnFloorChanged;

        public int CurrentFloor
        {
            get => _currentFloor;
            set
            {
                if (_currentFloor == value)
                    return;

                _currentFloor = value;
                InvokeFloorChanged(value);
            }
        }

        public FloorHandler(List<Floor> floors)
        {
            Floors = SortFloors(floors);
        }

        public void InvokeFloorChanged(int value)
        {
            OnFloorChanged?.Invoke(value);
        }

        protected override void SubscribeGridBuildMethods()
        {
        }

        protected override void UnsubscribeGridBuildMethods()
        {
        }

        private List<Floor> SortFloors(List<Floor> floors)
        {
            floors.Sort((floor1, floor2) => floor1.FloorIndex.CompareTo(floor2.FloorIndex));

            return floors;
        }
    }
}