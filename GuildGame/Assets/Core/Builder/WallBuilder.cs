using System.Collections.Generic;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal class WallBuilder: GridBuilderBase
    {
        public WallBuilder(LayerMask placeRaycast, LayerMask wallLayer) : base(placeRaycast, wallLayer)
        {
        }

        public WallBuilder(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer) : base(wallGridSize, placeRaycast, wallLayer)
        {
        }

        public override void Draw(Builder builder, List<GameObject> prefabToUse)
        {
            throw new System.NotImplementedException();
        }

        public override void Create(Builder builder, List<GameObject> prefabToUse)
        {
            throw new System.NotImplementedException();
        }

        public override void Destroy(Builder builder)
        {
            throw new System.NotImplementedException();
        }
    }
}