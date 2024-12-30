using UnityEngine;

public static class Utils
{
    public static Vector2 Rotate2D(Vector2 vec, float deg)
    {
        float radAngle = deg * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radAngle);
        float cos = Mathf.Cos(radAngle);
        return new Vector2(vec.x * cos - vec.y * sin, vec.x * sin + vec.y * cos);
    }

    public static Vector2 PolarToCartesian(float r, float deg)
    {
        float radAngle = deg * Mathf.Deg2Rad;
        return new Vector2(r * Mathf.Cos(radAngle), r * Mathf.Sin(radAngle));
    }

    public static Vector3 Mult(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
}
