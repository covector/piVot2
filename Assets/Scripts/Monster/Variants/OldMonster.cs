using UnityEngine;

public class OldMonster : Monster
{
    public float searchPeriod = 0f;
    private float searchCooldown = float.PositiveInfinity;
    private Vector3 memorizedPos = Vector2.zero;
    public override void Face()
    {
        searchCooldown += Time.fixedDeltaTime;
        if (searchCooldown > searchPeriod)
        {
            searchCooldown = 0;
            memorizedPos = target.position;
        }

        LookAt(memorizedPos - transform.position);
    }
}