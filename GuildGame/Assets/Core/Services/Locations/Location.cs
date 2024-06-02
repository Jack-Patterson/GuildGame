using System.Collections.Generic;
using com.Halkyon.Utils;
using UnityEngine;

namespace com.Halkyon.Services.Locations
{
    [CreateAssetMenu(menuName = "Halkyon/New Location", fileName = "New Location")]
    public class Location : ScriptableObject
    {
        public new string name;
        public List<Vector2> area;
        
        public bool IsPointInArea(Vector2 point)
        {
            Polygon polygon = new Polygon(area);
            
            return polygon.ContainsPoint(point);
        }
    }
}