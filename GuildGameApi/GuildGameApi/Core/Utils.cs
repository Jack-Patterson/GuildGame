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

    public static (T, int) OverlapAreaGetItemAndCheckForAnotherType<T>(Vector3 position, float radius, LayerMask layer,
        Type type)
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

    public static List<T> GetComponentsFromTransform<T>(Transform transform)
    {
        List<T> components = new List<T>();
        foreach (Transform child in transform)
        {
            T component = child.GetComponent<T>();
            if (component != null)
            {
                components.Add(component);
            }
        }

        return components;
    }

    public static Vector3 ClampVector3(Vector3 vector, float min, float max)
    {
        return new Vector3(Mathf.Clamp(vector.x, min, max), Mathf.Clamp(vector.y, min, max),
            Mathf.Clamp(vector.z, min, max));
    }

    public static Vector3 ClampVector3(Vector3 vector, Vector3 minimums, Vector3 maximums)
    {
        return new Vector3(Mathf.Clamp(vector.x, minimums.x, maximums.x), Mathf.Clamp(vector.y, minimums.y, maximums.y),
            Mathf.Clamp(vector.z, minimums.z, maximums.z));
    }

    public static Vector3 ClampVector3OnlyXZ(Vector3 vector, float min, float max)
    {
        return new Vector3(Mathf.Clamp(vector.x, min, max), vector.y, Mathf.Clamp(vector.z, min, max));
    }
}