using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float timePassed;
    private IEnumerator Shake(float time, float magnitude)
    {
        float variation = Random.Range(0f, 100f);
        timePassed = 0;
        Vector3 origin = transform.position;
        while (timePassed < time)
        {
            transform.position = origin + magnitude * (1 - timePassed / time) * new Vector3(Mathf.PerlinNoise(variation + 20f * timePassed, 0) - 0.5f, Mathf.PerlinNoise(0, variation + 20f * timePassed) - 0.5f, 0);
            timePassed += Time.deltaTime;
            yield return null;
        }
    }
    public void InitShake(float time, float magnitude)
    {
        StartCoroutine(Shake(time, magnitude));
    }
}