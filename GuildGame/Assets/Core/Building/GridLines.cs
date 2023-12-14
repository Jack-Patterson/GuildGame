using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class GridLines
    {
        private Builder _builder;
        
        private readonly int _spacing = 10;

        public GridLines(Builder builder)
        {
            _builder = builder;
        }
        
        internal void CreateGrid()
        {
            ClearGrid();

            for (int i = 0; i < _builder.Floors.Count; i++)
            {
                for (int j = 50; j >= -50; j -= _spacing)
                {
                    Vector3 vector1 = new Vector3(j, 0.1f + (10 * i), 50);
                    Vector3 vector2 = new Vector3(j, 0.1f + (10 * i), -50);
                    CreateLineRenderer(vector1, vector2, 0.2f, i+1);

                    vector1 = new Vector3(50, 0.1f + (10 * i), j);
                    vector2 = new Vector3(-50, 0.1f + (10 * i), j);
                    CreateLineRenderer(vector1, vector2, 0.2f, i+1);

                    if (j - _spacing < -50) continue;
                    for (int k = j - 2; k > j - _spacing; k -= 2)
                    {
                        vector1 = new Vector3(k, 0.1f + (10 * i), 50);
                        vector2 = new Vector3(k, 0.1f + (10 * i), -50);
                        CreateLineRenderer(vector1, vector2, 0.05f, i+1);

                        vector1 = new Vector3(50, 0.1f + (10 * i), k);
                        vector2 = new Vector3(-50, 0.1f + (10 * i), k);
                        CreateLineRenderer(vector1, vector2, 0.05f, i+1);
                    }
                }
            }
        }

        internal void ClearGrid()
        {
            LineRenderer[] existingLines = Object.FindObjectsOfType<LineRenderer>();
            foreach (LineRenderer line in existingLines)
            {
                Object.DestroyImmediate(line.gameObject);
            }
        }

        private void CreateLineRenderer(Vector3 startPoint, Vector3 endPoint, float width, int floorIndex)
        {
            GameObject lineObject = new GameObject("Line");

            lineObject.transform.parent = GetFloorFromIndex(floorIndex, _builder.Floors).transform;
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            
            Material brightMaterial = new Material(Shader.Find("Standard"));
            brightMaterial.EnableKeyword("_EMISSION");
            brightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            brightMaterial.SetColor("_EmissionColor", Color.white);
            
            lineRenderer.material = brightMaterial;

            lineRenderer.widthMultiplier = width;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
        }
        
        private Floor GetFloorFromIndex(int floorIndex, List<Floor> floors)
        {
            foreach (Floor floor in floors)
            {
                if (floor.FloorIndex == floorIndex)
                {
                    return floor;
                }
            }

            return null;
        }

        internal void DisplayFloor(int floorIndex)
        {
            Floor firstFloor = GetFloorFromIndex(1, _builder.Floors);
            Floor secondFloor = GetFloorFromIndex(2, _builder.Floors);
            Floor thirdFloor = GetFloorFromIndex(3, _builder.Floors);
            
            switch (floorIndex)
            {
                case 0:
                    firstFloor.transform.gameObject.SetActive(false);
                    secondFloor.transform.gameObject.SetActive(false);
                    thirdFloor.transform.gameObject.SetActive(false);
                    break;
                case 1:
                    firstFloor.transform.gameObject.SetActive(true);
                    secondFloor.transform.gameObject.SetActive(false);
                    thirdFloor.transform.gameObject.SetActive(false);
                    break;
                case 2:
                    firstFloor.transform.gameObject.SetActive(false);
                    secondFloor.transform.gameObject.SetActive(true);
                    thirdFloor.transform.gameObject.SetActive(false);
                    break;
                case 3:
                    firstFloor.transform.gameObject.SetActive(false);
                    secondFloor.transform.gameObject.SetActive(false);
                    thirdFloor.transform.gameObject.SetActive(true);
                    break;
                case 4:
                    firstFloor.transform.gameObject.SetActive(true);
                    secondFloor.transform.gameObject.SetActive(true);
                    thirdFloor.transform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}