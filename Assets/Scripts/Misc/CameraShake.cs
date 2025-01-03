using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float timePassed;
    IEnumerator current = null;
    Vector3 origin;

    private void Start()
    {
        origin = transform.position;
    }

    private IEnumerator Shake(float time, float magnitude)
    {
        float variation = Random.Range(0f, 100f);
        timePassed = 0;
        while (timePassed < time)
        {
            transform.position = origin + magnitude * (1 - timePassed / time) * new Vector3(Mathf.PerlinNoise(variation + 20f * timePassed, 0) - 0.5f, Mathf.PerlinNoise(0, variation + 20f * timePassed) - 0.5f, 0);
            timePassed += Time.deltaTime;
            yield return null;
        }
        current = null;
        transform.position = origin;
    }
    public void InitShake(float time, float magnitude)
    {
        if (current != null) { StopCoroutine(current); }
        StartCoroutine(current = Shake(time, magnitude));
    }
}