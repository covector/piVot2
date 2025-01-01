using UnityEngine;
using static Utils;

[RequireComponent(typeof(Monster))]
public class MonsterSpawn : MonoBehaviour
{
    public GameObject spawnParticle;

    void Awake()
    {   
        GetComponent<Monster>().enabled = false;
        Instantiate(spawnParticle, transform.position, Quaternion.identity, FindFirstObjectByType<PhoneScreenScaler>().transform);
        RunDelay(this, () => GetComponent<Monster>().enabled = true, 1f);
    }
}
