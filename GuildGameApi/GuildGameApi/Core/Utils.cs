using UnityEngine;

namespace com.Halcyon.API.Core;

public class Utils
{
    public static string AddSuffixIfNotExists(string stringToCheck, string suffix)
    {
        return stringToCheck.EndsWith(suffix) ? stringToCheck : $"{stringToCheck}{suffix}";
    }
    
    public static bool ValidateVectorSameAsAnother(Vector3 vector1, Vector3 vector2)
    {
        return vector1 == vector2;
    }
    
    public static T GetComponentFromColliderArray<T>(Collider[] colliders)
    {
        foreach (Collider collider in colliders)
        {
            T objectToFind = collider.GetComponent<T>();
            if (objectToFind != null)
            {
                return objectToFind;
            }
        }

        return default!;
    }
    
    public static T GetComponentFromColliderArray<T>(List<Collider> colliders)
    {
        return GetComponentFromColliderArray<T>(colliders.ToArray());
    }

    public static GameObject? GetPrefabFromListByScript<T>(GameObject?[] prefabs)
    {
        foreach (GameObject? go in prefabs)
        {
            if (go != null && go.GetComponent<T>() != null)
            {
                return go;
            }
        }

        return null;
    }
    
    public static GameObject? GetPrefabFromListByScript<T>(List<GameObject> prefabs)
    {
        return GetPrefabFromListByScript<T>(prefabs.ToArray());
    }
    
    public static T OverlapAreaGetItem<T>(Vector3 position, float radius, LayerMask layer)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius, layer);
        T item = GetComponentFromColliderArray<T>(colliders);
        
        return item;
    }
    
    public static (T, int) OverlapAreaGetItemAndCheckForAnotherType<T>(Vector3 position, float radius, LayerMask layer, Type type)
    {
        List<Type> listOfType = new List<Type>();
        
        Collider[] colliders = Physics.OverlapSphere(position, radius, layer);
        T item = GetComponentFromColliderArray<T>(colliders);
        
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent(type) != null)
            {
                listOfType.Add(type);
            }
        }
        
        return (item, listOfType.Count);
    }

    public static bool OverlapAreaContainsItem<T>(Vector3 position, float radius, LayerMask layer)
    {
        return OverlapAreaGetItem<T>(position, radius, layer) != null;
    }
}