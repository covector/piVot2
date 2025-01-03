using System.Collections;
using UnityEngine;
using static Utils;

public class MonsterSpawner : Spawner
{
    private IEnumerator spawnRoutine;

    protected override void CleanUp()
    {
        if (spawnRoutine != null) { StopCoroutine(spawnRoutine); }
        spawnRoutine = null;
    }

    public override void ScheduleSpawn(int index)
    {
        spawnedObjects[index] = null;
        if (spawnRoutine != null) { return; }
        spawnRoutine = RunDelay(this, () =>
        {
            Spawn(index);
            spawnRoutine = null;
            CheckUnderSpawn();
        }, spawnDelay);
    }

    public void CheckUnderSpawn()
    {
        if (spawnRoutine == null)
        {
            for (int i = 0; i < maxSpawn; i++)
            {
                if (spawnedObjects[i] == null)
                {
                    ScheduleSpawn(i);
                    return;
                }
            }
        }
    }
}
