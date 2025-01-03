using UnityEngine;

public class Spawnee : MonoBehaviour
{
    public int index;
    public Spawner spawner;

    public void Respawn()
    {
        spawner.ScheduleSpawn(index);
    }
}
