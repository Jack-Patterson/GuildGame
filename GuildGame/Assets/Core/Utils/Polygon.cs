using System.Collections.Generic;
using UnityEngine;

namespace com.Halkyon.Utils
{
    public class Polygon
    {
        public readonly List<Vector2> Vertices;

        public Polygon(List<Vector2> vertices)
        {
            Vertices = vertices;
        }

        /// <summary>
        /// Check if a point is inside a polygon. Uses raycast algorithm.
        /// </summary>
        /// <param name="point">Point to check against the polygon.</param>
        /// <returns></returns>
        public bool ContainsPoint(Vector2 point)
        {
            int j = Vertices.Count - 1;
            bool containsPoint = false;
            for (int i = 0; i < Vertices.Count; j = i++)
            {
                if (((Vertices[i].y <= point.y && point.y < Vertices[j].y) ||
                     (Vertices[j].y <= point.y && point.y < Vertices[i].y)) &&
                    (point.x < (Vertices[j].x - Vertices[i].x) * (point.y - Vertices[i].y) /
                        (Vertices[j].y - Vertices[i].y) + Vertices[i].x))
                    containsPoint = !containsPoint;
            }

            return containsPoint;
        }
    }
}