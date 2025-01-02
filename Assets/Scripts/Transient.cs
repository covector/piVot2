using UnityEngine;

public class Transient : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
