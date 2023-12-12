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
}