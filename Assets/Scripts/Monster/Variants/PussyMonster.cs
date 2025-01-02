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
    public float runSpeedUp = 1f;
    private bool running = false;
    public override void Face()
    {
        Vector2 vec = target.position - transform.position;

        if (!running && vec.sqrMagnitude < pussyRange * pussyRange && pussyCount > 0)
        {
            pussyCount--;
            running = true;
            RunDelay(this, () => running = false, runTime);
        }

        LookAt(running ? -vec : vec);
    }

    public override void Walk()
    {
        rb.MovePosition(rb.position + PolarToCartesian((running ? runSpeedUp : 1f) * speed * Time.fixedDeltaTime, transform.eulerAngles.z));
    }

    new void Start()
    {
        base.Start();
        pussyCount = Random.Range(minPussyCount, maxPussyCount + 1);
    }
}