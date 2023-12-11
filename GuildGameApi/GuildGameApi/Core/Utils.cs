namespace com.Halcyon.API.Core;

public class Utils
{
    public static string AddSuffixIfNotExists(string stringToCheck, string suffix)
    {
        return stringToCheck.EndsWith(suffix) ? stringToCheck : $"{stringToCheck}{suffix}";
    }
}