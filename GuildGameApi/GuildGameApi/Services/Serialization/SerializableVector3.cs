using UnityEngine;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }
    
    public Vector3 GetUnityVector() => new(x, y, z);

    public static List<SerializableVector3> GetSerializableListOfUnityVector3(List<Vector3> vList)
    {
        List<SerializableVector3> list = new List<SerializableVector3>(vList.Count);
        foreach (Vector3 vector in vList)
        {
            list.Add(new SerializableVector3(vector));
        }

        return list;
    }

    public static List<Vector3> GetUnityVector3ListOfSerializable(List<SerializableVector3> vList)
    {
        List<Vector3> list = new List<Vector3>(vList.Count);
        foreach (SerializableVector3 serializableVector in vList)
        {
            list.Add(serializableVector.GetUnityVector());
        }

        return list;
    }
}