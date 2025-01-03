using System;
using System.Collections;
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

    //public static void RunDelay(Action action, float delay, bool unscaledTime = false)
    //{
    //    GameManager.instance.StartCoroutine(_RunDelay(action, delay, unscaledTime));
    //}
    public static IEnumerator RunDelay(MonoBehaviour mb, Action action, float delay, bool unscaledTime = false)
    {
        IEnumerator coroutine = _RunDelay(action, delay, unscaledTime);
        mb.StartCoroutine(coroutine);
        return coroutine;
    }
    public static IEnumerator _RunDelay(Action action, float delay, bool unscaledTime = false)
    {
        yield return unscaledTime ? new WaitForSecondsRealtime(delay) : new WaitForSeconds(delay);
        action();
    }
}
