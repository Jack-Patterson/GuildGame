using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal class GridBuilder
    {
        private int _gridSize = Constants.DefaultGridSize;

        public GridBuilder()
        {
            
        }

        public GridBuilder(int gridSize)
        {
            _gridSize = gridSize;
        }
    }
}