using UnityEngine;

public class DrunkMonster : Monster
{
    public float maxOffsetAngle = 0f;
    public float swingSpeed = 1f;
    [SerializeField]
    private float offsetAngle = 0f;
    private int swing = 1;
    public override void Face()
    {
        offsetAngle += swing * swingSpeed * Time.fixedDeltaTime;
        if (offsetAngle > maxOffsetAngle) {
            swing = -1;
            offsetAngle = maxOffsetAngle;
        } else if (offsetAngle < -maxOffsetAngle)
        {
            swing = 1;
            offsetAngle = -maxOffsetAngle;
        }
        LookAt(target.position - transform.position, offsetAngle);
    }
}