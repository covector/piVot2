using UnityEngine;
using static Utils;

public class Spawner : MonoBehaviour
{
    public BoxCollider2D topWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    Vector2 areaMin;
    Vector2 areaMax;
    public GameObject prefab;
    public int maxCrystals = 4;
    const float spawnDelay = 1f;
    public Vector2 paddingX;
    public Vector2 paddingY;

    void Start()
    {
        areaMax = new Vector2(rightWall.bounds.min.x - paddingX.y, topWall.bounds.min.y - paddingY.y);
        areaMin = new Vector2(leftWall.bounds.max.x + paddingX.x, bottomWall.bounds.max.y + paddingY.x);
    }

    public void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y));
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity, transform);
    }

    public void SpawnTillEnough()
    {
        RunDelay(this, () =>
        {
            if (transform.childCount < maxCrystals)
            {
                Spawn();
                SpawnTillEnough();
            }
        }, spawnDelay);
    }
}
