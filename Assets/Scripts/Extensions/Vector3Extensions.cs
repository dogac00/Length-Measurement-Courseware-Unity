
using UnityEngine;

public static class Vector3Extensions
{
    public static bool IsClose(this Vector3 vector3, Vector3 other, float difference)
    {
        return Mathf.Abs(vector3.x - other.x) < difference &&
               Mathf.Abs(vector3.y - other.y) < difference;
    }
}
