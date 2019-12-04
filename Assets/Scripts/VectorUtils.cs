using UnityEngine;

public static class VectorUtils
{
    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }
}
