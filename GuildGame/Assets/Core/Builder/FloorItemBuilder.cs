﻿using System.Collections.Generic;
using UnityEngine;

namespace com.Halcyon.Core.Builder
{
    internal class FloorItemBuilder: GridBuilderBase
    {
        public FloorItemBuilder(LayerMask placeRaycast, LayerMask wallLayer) : base(placeRaycast, wallLayer)
        {
        }

        public FloorItemBuilder(int wallGridSize, LayerMask placeRaycast, LayerMask wallLayer) : base(wallGridSize, placeRaycast, wallLayer)
        {
        }

        protected override void Draw(Transform parent, List<GameObject> prefabsToUse)
        {
            throw new System.NotImplementedException();
        }

        protected override void Destroy(Builder builder)
        {
            throw new System.NotImplementedException();
        }

        protected override void SubscribeGridBuildMethods()
        {
            throw new System.NotImplementedException();
        }

        protected override void UnsubscribeGridBuildMethods()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnMousePositionChanged(RaycastHit value)
        {
            throw new System.NotImplementedException();
        }
    }
}