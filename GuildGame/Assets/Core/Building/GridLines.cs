using UnityEngine;

namespace com.Halcyon.Core.Building
{
    public class GridLines
    {
        private int _spacing = 10;
        private int _gridZ = 10;
        private int _gridX = 10;

        private Vector2 pos1 = new Vector2(50, 50);
        private Vector2 pos2 = new Vector2(-50, -50);

        // private void Start()
        // {
        //     CreateGrid();
        // }
        //
        // private void CreateGrid()
        // {
        //     // ClearGrid();
        //
        //     for (int x = 50; x >= -50; x -= _spacing)
        //     {
        //         Vector3 vector1 = new Vector3(x, .1f, -50);
        //         Vector3 vector2 = new Vector3(x, .1f, 50);
        //         CreateLineRenderer(vector1, vector2);
        //     }
        //
        //     for (int z = 50; z >= -50; z -= _spacing)
        //     {
        //         Vector3 vector1 = new Vector3(50, .1f, z);
        //         Vector3 vector2 = new Vector3(-50, .1f, z);
        //         CreateLineRenderer(vector1, vector2);
        //     }
        // }
        //
        // private void CreateLineRenderer(Vector3 startPoint, Vector3 endPoint, Transform transform)
        // {
        //     GameObject lineObject = new GameObject("Line");
        //     lineObject.transform.parent = transform;
        //     LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        //     lineRenderer.widthMultiplier = 0.1f;
        //     lineRenderer.positionCount = 2;
        //     lineRenderer.SetPosition(0, startPoint);
        //     lineRenderer.SetPosition(1, endPoint);
        // }

        // private void ClearGrid()
        // {
        //     LineRenderer[] existingLines = FindObjectsOfType<LineRenderer>();
        //     foreach (LineRenderer line in existingLines)
        //     {
        //         DestroyImmediate(line.gameObject);
        //     }
        // }

        // [CustomEditor(typeof(GridLines))]
        // public class GridLineRendererEditor : Editor
        // {
        //     public override void OnInspectorGUI()
        //     {
        //         DrawDefaultInspector();
        //
        //         GridLines gridLines = (GridLines)target;
        //
        //         if (GUILayout.Button("Generate Grid"))
        //         {
        //             gridLines.CreateGrid();
        //         }
        //
        //         if (GUILayout.Button("Remove Grid"))
        //         {
        //             gridLines.ClearGrid();
        //         }
        //
        //         Color c = EditorGUILayout.ColorField("Color", Color.white, new GUILayoutOption[] { });
        //     }
        // }
    }
}