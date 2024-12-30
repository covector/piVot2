using UnityEngine;

public class ExpoMonster : Monster
{
    public override void Face()
    {
        Vector2 vec = target.position - transform.position;
        float targetAngle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        float viewAngle = transform.eulerAngles.z;
        targetAngle = (targetAngle + 360) % 360;

        targetAngle += (viewAngle > targetAngle + 180 ? 360 : 0) - (viewAngle < targetAngle - 180 ? 360 : 0);

        float delta = targetAngle - viewAngle;
        viewAngle += delta * 0.01f * Time.timeScale; //Exponential / Frame Dependent

        transform.eulerAngles = new Vector3(0f, 0f, viewAngle);
    }
}