using System;
using UnityEditor;
using UnityEngine;

namespace com.Halcyon.Core.Building
{
    [CustomEditor(typeof(Builder))]
    public class BuilderEditor : Editor
    {
        private SerializedProperty _floorNamesProp;
        
        private void OnEnable()
        {
            _floorNamesProp = serializedObject.FindProperty("floors");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();
            
            Builder builder = (Builder)target;
            GridLines gridLines = new GridLines(builder);
            
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Grid Layout", EditorStyles.boldLabel);
            
            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Generate Grid"))
            {
                gridLines.CreateGrid();
            }

            if (GUILayout.Button("Remove Grid"))
            {
                gridLines.ClearGrid();
            }
            
            if (GUILayout.Button("Get Floors"))
            {
                builder.GetFloors();
            }
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.PropertyField(_floorNamesProp, true);
            
            EditorGUILayout.LabelField("Select floors to display.");
            
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("1st Floor"))
            {
                Debug.Log("Button 1 clicked");
                gridLines.DisplayFloor(1);
            }

            if (GUILayout.Button("2nd Floor"))
            {
                Debug.Log("Button 2 clicked");
                gridLines.DisplayFloor(2);
            }

            if (GUILayout.Button("3rd Floor"))
            {
                Debug.Log("Button 3 clicked");
                gridLines.DisplayFloor(3);
            }

            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("No Floors"))
            {
                Debug.Log("No Floors clicked");
                gridLines.DisplayFloor(0);
            }

            if (GUILayout.Button("All Floors"))
            {
                Debug.Log("All Floors clicked");
                gridLines.DisplayFloor(4);
            }
            
            EditorGUILayout.EndHorizontal();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}