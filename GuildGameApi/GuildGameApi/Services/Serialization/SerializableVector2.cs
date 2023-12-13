using UnityEngine;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableVector2
{
    public float x;
    public float y;

    public SerializableVector2(Vector2 vector)
    {
        x = vector.x;
        y = vector.y;
    }
    
    public Vector2 GetUnityVector() => new(x, y);

    public static List<SerializableVector2> GetSerializableListOfUnityVector2(List<Vector2> vList)
    {
        List<SerializableVector2> list = new List<SerializableVector2>(vList.Count);
        foreach (Vector2 vector in vList)
        {
            list.Add(new SerializableVector2(vector));
        }

        return list;
    }

    public static List<Vector2> GetUnityVector2ListOfSerializable(List<SerializableVector2> vList)
    {
        List<Vector2> list = new List<Vector2>(vList.Count);
        foreach (SerializableVector2 serializableVector in vList)
        {
            list.Add(serializableVector.GetUnityVector());
        }

        return list;
    }
}