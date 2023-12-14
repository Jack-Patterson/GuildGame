using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class Floor: MonoBehaviour
    {
        [SerializeField] private int floorIndex;

        public int FloorIndex
        {
            get => floorIndex;
            set => floorIndex = value;
        }
    }
}