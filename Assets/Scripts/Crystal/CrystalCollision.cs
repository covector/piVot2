using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CrystalCollision : MonoBehaviour
{
    public Sprite[] variations;

    private void Awake()
    {
        if (Random.Range(0, 2) == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        int ind = Random.Range(0, variations.Length);
        GetComponent<SpriteRenderer>().sprite = variations[ind];
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            FindFirstObjectByType<ScoreCounter>().Increment();
            FindFirstObjectByType<CrystalSpawner>().SpawnTillEnough();
            Destroy(gameObject);
        }
    }
}
