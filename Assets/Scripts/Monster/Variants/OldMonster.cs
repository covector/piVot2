using UnityEngine;

public class OldMonster : Monster
{
    public float searchPeriod = 0f;
    private float searchCooldown = float.PositiveInfinity;
    private Vector3 memorizedPos = Vector2.zero;
    public override void Face()
    {
        searchCooldown += Time.deltaTime;
        if (searchCooldown > searchPeriod)
        {
            searchCooldown = 0;
            memorizedPos = target.position;
        }

        Vector2 vec = memorizedPos - transform.position;
        float targetAngle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        float viewAngle = transform.eulerAngles.z;
        targetAngle = (targetAngle + 360) % 360;

        targetAngle += (viewAngle > targetAngle + 180 ? 360 : 0) - (viewAngle < targetAngle - 180 ? 360 : 0);

        float delta = targetAngle - viewAngle;
        viewAngle += Mathf.Sign(delta) * Mathf.Min(200 * Time.deltaTime, Mathf.Abs(delta));

        transform.eulerAngles = new Vector3(0f, 0f, viewAngle);
        
    }
}