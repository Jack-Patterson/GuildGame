using System.Collections.Generic;
using UnityEngine;

namespace com.Halkyon.Locations
{
    public class LocationManager : ExtendedMonoBehaviour
    {
        private static List<Location> _locations = new();
        
        public static List<Location> Locations
        {
            get
            {
                if (_locations == null || _locations.Count == 0)
                {
                    _locations = LoadLocations();
                }

                return _locations;
            }
        }
        
        private static List<Location> LoadLocations()
        {
            Location[] loadedLocations = Resources.LoadAll<Location>("Locations");
            return new List<Location>(loadedLocations);
        }
        
        public static Location GetLocationOfPoint(Vector2 point)
        {
            foreach (Location location in Locations)
            {
                if (location.IsPointInArea(point))
                {
                    return location;
                }
            }

            return null;
        }
    }
}