using UnityEngine;

public class FPSMaxing : MonoBehaviour
{
    void Start()
    {
        Resolution[] allResolutions = Screen.resolutions;
        int maxRefresh = 30;
        foreach (Resolution res in allResolutions)
        {
            maxRefresh = Mathf.Max(maxRefresh, Mathf.RoundToInt((float)res.refreshRateRatio.value));
        }
        maxRefresh = Mathf.Clamp(maxRefresh, 30, 300);
        Application.targetFrameRate = maxRefresh;
    }
}
