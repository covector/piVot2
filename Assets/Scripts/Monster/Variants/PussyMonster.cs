using UnityEngine;
using static Utils;

public class PussyMonster : Monster
{
    public int minPussyCount = 0;
    public int maxPussyCount = 0;
    [SerializeField]
    private int pussyCount = 0;
    public float pussyRange = 0f;
    public float runTime = 0f;
    private float runTimer = 0f;
    private bool running = false;
    public override void Face()
    {
        Vector2 vec = target.position - transform.position;

        if (running)
        {
            runTimer += Time.deltaTime;
            if (runTimer > runTime)
            {
                running = false;
                runTimer = 0f;
            }
        }
        else if (vec.sqrMagnitude < pussyRange * pussyRange && pussyCount > 0)
        {
            pussyCount--;
            running = true;
        }

        LookAt(vec);
    }

    public override void Walk()
    {
        rb.MovePosition(rb.position + PolarToCartesian((running ? 1.5f : 1f) * speed * PhoneScreenScaler.screenScale * Time.fixedDeltaTime, transform.eulerAngles.z));
    }

    new void Start()
    {
        base.Start();
        pussyCount = Random.Range(minPussyCount, maxPussyCount + 1);
    }
}