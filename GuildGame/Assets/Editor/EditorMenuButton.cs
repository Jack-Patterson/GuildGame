using System;
using System.Collections.Generic;
using System.Linq;
using com.Halcyon.Core;
using UnityEditor;
using UnityEngine;

namespace com.Halkyon.Editor
{
    public class EditorMenuButton : EditorWindow
    {
        private List<Type> addableTypes;
        private Dictionary<Type, bool> selectedTypes;
        private Dictionary<Type, SerializedObject> serializedObjects = new Dictionary<Type, SerializedObject>();
        private Dictionary<Type, GameObject> tempObjects = new Dictionary<Type, GameObject>();
        private bool separateObjects = false;

        [MenuItem("Halkyon/ComponentsAdder")]
        public static void ShowWindow()
        {
            GetWindow(typeof(EditorMenuButton), true, "Add Components");
        }

        void OnEnable()
        {
            LoadAddableTypes();
        }

        void OnDestroy()
        {
            foreach (var obj in tempObjects.Values)
            {
                DestroyImmediate(obj);
            }

            tempObjects.Clear();
            serializedObjects.Clear();
        }

        private void LoadAddableTypes()
        {
            addableTypes = new List<Type>();
            selectedTypes = new Dictionary<Type, bool>();

            var query = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsClass && type.Namespace != null && type.Namespace.StartsWith("com.Halcyon.Core") &&
                      typeof(IEditorAddable).IsAssignableFrom(type)
                select type;

            foreach (Type type in query)
            {
                addableTypes.Add(type);
                selectedTypes[type] = false;
                GameObject
                    tempObject = new GameObject("TempObject", type);
                tempObjects[type] = tempObject;
                SerializedObject serializedObject = new SerializedObject(tempObject.GetComponent(type));
                serializedObjects[type] = serializedObject;
            }
        }

        void OnGUI()
        {
            GUILayout.Label("Instantiate as separate objects", EditorStyles.boldLabel);
            separateObjects = EditorGUILayout.ToggleLeft("Checked = YES, Unchecked = NO", separateObjects);
            
            GUILayout.Label("Select Components to Add:", EditorStyles.boldLabel);

            if (addableTypes.Count == 0)
            {
                GUILayout.Label("No addable components found.");
                return;
            }

            foreach (Type type in addableTypes)
            {
                bool prevState = selectedTypes[type];
                selectedTypes[type] = EditorGUILayout.ToggleLeft(type.Name, selectedTypes[type]);
                if (selectedTypes[type])
                {
                    SerializedObject serializedObject = serializedObjects[type];
                    SerializedProperty property = serializedObject.GetIterator();
                    property.NextVisible(true); // Skip the first property (script reference)
                    while (property.NextVisible(false))
                    {
                        EditorGUILayout.PropertyField(property, true);
                    }
                    serializedObject.ApplyModifiedProperties();  // Save changes made in the GUI
                }
                else if (prevState != selectedTypes[type])
                {
                    serializedObjects[type].Update(); // Reset the properties when deselected
                }
            }

            if (GUILayout.Button("Add Selected Components"))
            {
                CreateGameObjectsWithSelectedComponents();
            }
        }

        private void CreateGameObjectsWithSelectedComponents()
        {
            foreach (KeyValuePair<Type, bool> entry in selectedTypes)
            {
                if (entry.Value) // If selected
                {
                    GameObject newObject = separateObjects ? new GameObject(entry.Key.Name) : tempObjects[entry.Key];
                    var component = newObject.AddComponent(entry.Key) as IEditorAddable;
                    serializedObjects[entry.Key].ApplyModifiedProperties(); // Apply changes to the actual component
                    component?.OnAdd();
                    Debug.Log($"{entry.Key.Name} added to {newObject.name} and initialized.");

                    if (separateObjects)
                    {
                        newObject.name = entry.Key.Name;  // Naming the new object if separate
                    }
                }
            }
            // Optionally, destroy temporary objects after adding components if not separateObjects
            if (!separateObjects)
            {
                foreach (var obj in tempObjects.Values)
                {
                    DestroyImmediate(obj);
                }
                tempObjects.Clear();
            }
        }
    }
}