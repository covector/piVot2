using UnityEngine;

public class SmartMonster : Monster
{
    public float searchPeriod = 0f;
    private float searchCooldown = 0f;
    private Vector3[] memorizedPos;
    private float lookAheadFactor = 1f;
    public override void Face()
    {
        searchCooldown += Time.fixedDeltaTime;
        if (searchCooldown > searchPeriod)
        {
            searchCooldown = 0;
            memorizedPos[0] = memorizedPos[1];
            memorizedPos[1] = target.position;
        }

        Vector3 vec = target.position - transform.position;
        vec += vec.magnitude * lookAheadFactor * (memorizedPos[1] - memorizedPos[0]);
        LookAt(vec);
    }

    new void Start()
    {
        base.Start();
        memorizedPos = new Vector3[2] { target.position, target.position };
        lookAheadFactor = 1 / speed;
    }
}