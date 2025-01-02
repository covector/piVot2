using System.Collections;
using UnityEngine;
using static Utils;

[RequireComponent(typeof(SpriteRenderer))]
public class DelayedFade : MonoBehaviour
{
    public float delay;
    public float fadeTime;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        RunDelay(this, () => StartCoroutine(FadeCoroutine()), delay);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator FadeCoroutine()
    {

        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeTime;
            float alpha = Mathf.Lerp(1, 0, normalizedTime);
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        spriteRenderer.color = new Color(1, 1, 1, 0);
        Destroy(gameObject);
    }

}
