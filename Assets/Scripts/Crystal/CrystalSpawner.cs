using System.Collections;
using static Utils;

public class CrystalSpawner : Spawner
{
    private IEnumerator[] spawnRoutines;

    protected override void CleanUp()
    {
        if (spawnRoutines != null)
        {
            foreach (IEnumerator routine in spawnRoutines)
            {
                if (routine != null) { StopCoroutine(routine); }
            }
        }
        if (spawnRoutines == null) { spawnRoutines = new IEnumerator[maxSpawn]; }
        for (int i = 0; i < maxSpawn; i++)
        {
            spawnRoutines[i] = null;
        }
    }

    public override void ScheduleSpawn(int index)
    {
        spawnedObjects[index] = null;
        if (spawnRoutines[index] != null) { return; }
        spawnRoutines[index] = RunDelay(this, () =>
        {
            Spawn(index);
            spawnRoutines[index] = null;
        }, spawnDelay);
    }
}
