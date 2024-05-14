﻿using com.Halkyon.AI.Character.Attributes;
using com.Halkyon.Locations;
using UnityEngine;

namespace com.Halkyon.AI.Interaction.Quests
{
    [CreateAssetMenu(menuName = "Halkyon/New Quest", fileName = "New Quest")]
    public class Quest : ScriptableObject
    {
        public new string name = "";
        public CharacterRank requiredRank = CharacterRank.F;
        public string description = "";
        public QuestType questType = QuestType.Fetch;
        public Vector3 locationCoordinates = Vector3.zero;
        private string _location;

        public string Location
        {
            get
            {
                Location pointLocation =
                    LocationManager.GetLocationOfPoint(new Vector2(locationCoordinates.x, locationCoordinates.z));

                if (pointLocation != null)
                {
                    _location = pointLocation.name;
                }
                else
                {
                    _location = "Unknown Location";
                }


                return _location;
            }
        }

        private void OnDestroy()
        {
            _location = null;
        }
    }
}