using UnityEngine;

[DisallowMultipleComponent]
public class PhoneScreenScaler : MonoBehaviour
{
    public Vector2 minVisibility = Vector2.one;

    void Start()
    {
        Vector2 camTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        float xRatio = minVisibility.x / camTopRight.x;
        float yRatio = minVisibility.y / camTopRight.y;
        if (xRatio > 1f || yRatio > 1f)
        {
            Camera.main.orthographicSize *= Mathf.Max(xRatio, yRatio);
        } else
        {
            if (Mathf.Approximately(xRatio, 1f) || Mathf.Approximately(yRatio, 1f)) { return; }
            Camera.main.orthographicSize *= Mathf.Min(xRatio, yRatio);
        }
    }
#if UNITY_EDITOR
    void Update()
    {
        Start();
    }
#endif
}
