using UnityEngine;
using static Utils;

public class Monster : MonoBehaviour
{
    protected Transform target;
    public float speed;
    protected Rigidbody2D rb;
    public GameObject explodeEffect;
    protected bool moving = false;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindFirstObjectByType<PlayerSpawner>().player.transform;
        transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
        moving = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    public void StartMoving()
    {
        GetComponent<Rigidbody2D>().simulated = true;
        moving = true;
    }

    protected void Update()
    {
        if (moving)
        {
            Face();
            Walk();
        }
    }

    public virtual void Walk()
    {
        rb.MovePosition(rb.position + PolarToCartesian(speed * Time.fixedDeltaTime, transform.eulerAngles.z));
    }
    public virtual void Face()
    {
        LookAt(target.position - transform.position);
    }

    protected void LookAt(Vector2 vec, float targetAngleOffset = 0f)
    {
        float targetAngle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        float viewAngle = transform.eulerAngles.z;
        targetAngle = (targetAngle + 360) % 360;

        targetAngle += (viewAngle > targetAngle + 180 ? 360 : 0) - (viewAngle < targetAngle - 180 ? 360 : 0);

        float delta = targetAngle + targetAngleOffset - viewAngle;
        viewAngle += Mathf.Sign(delta) * Mathf.Min(200 * Time.deltaTime, Mathf.Abs(delta));

        transform.eulerAngles = new Vector3(0f, 0f, viewAngle);
    }

    public void Die()
    {
        transform.parent.GetComponent<Spawner>().SpawnTillEnough();
        Instantiate(explodeEffect, transform.position, Quaternion.Euler(new Vector3(0, 0, target.eulerAngles.z + 180f)), FindFirstObjectByType<PhoneScreenScaler>().transform);
        Destroy(gameObject);
    }
}
