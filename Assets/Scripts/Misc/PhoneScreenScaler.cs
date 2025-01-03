using UnityEngine;

[DisallowMultipleComponent]
public class PhoneScreenScaler : MonoBehaviour
{
    public Vector2 minVisibility = Vector2.one;
    Vector2 cachedSize = Vector2.zero;

    void Start()
    {
        Vector2 camTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        if (cachedSize.x == Screen.width && cachedSize.y == Screen.height) { return; }
        cachedSize = new Vector2(Screen.width, Screen.height);
        float xRatio = minVisibility.x / camTopRight.x;
        float yRatio = minVisibility.y / camTopRight.y;
        if (!(xRatio > 1f || yRatio > 1f) && (Mathf.Approximately(xRatio, 1f) || Mathf.Approximately(yRatio, 1f))) { return; }
        Camera.main.orthographicSize *= Mathf.Max(xRatio, yRatio);
    }

    void Update()
    {
        Start();
    }
}
