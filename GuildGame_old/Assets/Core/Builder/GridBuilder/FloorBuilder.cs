using System.Collections.Generic;
using UnityEngine;

namespace com.Halcyon.Core.Builder.GridBuilder
{
    internal class FloorBuilder: GridBuilderBase
    {
        public FloorBuilder(LayerMask placeRaycast, LayerMask wallLayer) : base(placeRaycast, wallLayer)
        {
        }

        public FloorBuilder(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer) : base(wallGridSize, placeRaycast, wallLayer)
        {
        }

        protected override void Draw(Transform parent, List<GameObject> prefabsToUse)
        {
            throw new System.NotImplementedException();
        }

        protected internal override void SubscribeGridBuildMethods()
        {
            Print("implemented");
        }

        protected internal override void UnsubscribeGridBuildMethods()
        {
            Print("unimplemented");
        }

        protected override void OnMousePositionChanged(RaycastHit value)
        {
            throw new System.NotImplementedException();
        }
    }
}