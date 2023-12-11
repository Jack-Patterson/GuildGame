using UnityEngine;

namespace com.Halcyon.API.Services.Serialization;

public class SerializableQuaternion
{
    public float x;
    public float y;
    public float z;
    public float w;

    public SerializableQuaternion(Quaternion quaternion)
    {
        x = quaternion.x;
        y = quaternion.y;
        z = quaternion.z;
        w = quaternion.w;
    }

    public Quaternion GetUnityQuaternion() => new(x, y, z, w);

    public static List<SerializableQuaternion> GetSerializableListOfUnityQuaternion(List<Quaternion> quaternions)
    {
        List<SerializableQuaternion> list = new List<SerializableQuaternion>(quaternions.Count);
        foreach (Quaternion quaternion in quaternions)
        {
            list.Add(new SerializableQuaternion(quaternion));
        }

        return list;
    }

    public static List<Quaternion> GetUnityQuaternionListOfSerializable(List<SerializableQuaternion> quaternions)
    {
        List<Quaternion> list = new List<Quaternion>(quaternions.Count);
        foreach (SerializableQuaternion serializableQuaternion in quaternions)
        {
            list.Add(serializableQuaternion.GetUnityQuaternion());
        }

        return list;
    }
}