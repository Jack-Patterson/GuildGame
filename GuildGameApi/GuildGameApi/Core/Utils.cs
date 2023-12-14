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
}