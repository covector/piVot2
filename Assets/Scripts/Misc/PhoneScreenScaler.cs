using UnityEngine;

public class PhoneScreenScaler : MonoBehaviour
{
    public float initScale;
    public static float screenScale { get; private set; }

    void Start()
    {
        Vector2 camTopRight = Camera.main.ViewportToWorldPoint(new Vector2(initScale, initScale));
        float minSide = Mathf.Min(camTopRight.x, camTopRight.y);
        transform.localScale = minSide * Vector2.one;
        screenScale = minSide / 9f;
    }
#if UNITY_EDITOR
    void Update()
    {
        Start();
    }
#endif
}
