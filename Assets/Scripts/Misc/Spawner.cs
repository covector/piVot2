using System.Collections;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public BoxCollider2D topWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    Vector2 areaMin;
    Vector2 areaMax;
    public GameObject prefab;
    public int maxSpawn = 4;
    public float spawnDelay = 1f;
    public Vector2 paddingX;
    public Vector2 paddingY;
    private IEnumerator initRoutine;
    protected GameObject[] spawnedObjects;

    void Start()
    {
        areaMax = new Vector2(rightWall.bounds.min.x - paddingX.y, topWall.bounds.min.y - paddingY.y);
        areaMin = new Vector2(leftWall.bounds.max.x + paddingX.x, bottomWall.bounds.max.y + paddingY.x);
    }

    public void Reset()
    {
        CleanUp();
        if (spawnedObjects == null) { spawnedObjects = new GameObject[maxSpawn]; }
        for (int i = 0; i < maxSpawn; i++)
        {
            spawnedObjects[i] = null;
        }
        if (initRoutine != null) { StopCoroutine(initRoutine); }
        StartCoroutine(initRoutine = SequentialSpawn());
    }

    public void Spawn(int index)
    {
        Vector2 pos = new Vector2(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y));
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity, transform);
        obj.GetComponent<Spawnee>().index = index;
        obj.GetComponent<Spawnee>().spawner = this;
        spawnedObjects[index] = obj;
    }

    IEnumerator SequentialSpawn()
    {
        for (int i = 0; i < maxSpawn; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Spawn(i);
        }
    }

    protected abstract void CleanUp();
    public abstract void ScheduleSpawn(int index);
}
