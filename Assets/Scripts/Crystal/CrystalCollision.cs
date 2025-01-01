using UnityEngine;
using static Utils;

[RequireComponent(typeof(SpriteRenderer))]
public class CrystalCollision : MonoBehaviour
{
    public Sprite[] variations;
    public GameObject particle;

    private void Awake()
    {
        if (Random.Range(0, 2) == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        int ind = Random.Range(0, variations.Length);
        GetComponent<SpriteRenderer>().sprite = variations[ind];
        GetComponent<SpriteRenderer>().enabled = false;
        RunDelay(this, () => GetComponent<SpriteRenderer>().enabled = true, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            FindFirstObjectByType<ScoreCounter>().Increment();
            GetComponent<Spawnee>().spawner.SpawnTillEnough();
            Instantiate(particle, transform.position, Quaternion.identity, FindFirstObjectByType<PhoneScreenScaler>().transform);
            Destroy(gameObject);
        }
    }
}
