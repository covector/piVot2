using UnityEngine;
using static Wall;

public class PlayerCollision : MonoBehaviour
{
    public PivotEngine engine;
    PlayerParticles particles;
    public bool head;
    private static bool loseFlag = false;
    private static bool killFlag = false;

    private void Start()
    {
        particles = engine.GetComponent<PlayerParticles>();
    }

    private void LateUpdate()
    {
        if (head) { return; }
        if (loseFlag && !killFlag)
        {
            foreach (Monster monster in FindObjectsByType<Monster>(FindObjectsSortMode.None))
            {
                monster.StopMoving();
            }
            GameManager.instance.GameOver();
            Destroy(engine.gameObject);
        }
        loseFlag = false;
        killFlag = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Monster":
                EnemyDetection(collider);
                break;
            case "Wall":
                WallDetection(collider);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Wall":
                WallDetection(collider);
                break;
        }
    }

    private void WallDetection(Collider2D collider)
    {
        WallDirection dir = collider.GetComponent<Wall>().wallDirection;
        engine.WallHit(head, dir);

        Transform contactPart = head ? engine.head : engine.tail;
        switch (dir)
        {
            case WallDirection.Up:
                particles.PlayWallHitParticles(new Vector2(contactPart.position.x, collider.bounds.min.y), dir);
                break;
            case WallDirection.Right:
                particles.PlayWallHitParticles(new Vector2(collider.bounds.min.x, contactPart.position.y), dir);
                break;
            case WallDirection.Down:
                particles.PlayWallHitParticles(new Vector2(contactPart.position.x, collider.bounds.max.y), dir);
                break;
            case WallDirection.Left:
                particles.PlayWallHitParticles(new Vector2(collider.bounds.max.x, contactPart.position.y), dir);
                break;
        }

        if (head)
        {
            FindFirstObjectByType<CameraShake>().InitShake(0.3f, 0.1f);
        }
    }

    private void EnemyDetection(Collider2D collider)
    {
        if (head)
        {
            collider.GetComponent<Monster>().Die();
            FindFirstObjectByType<CameraShake>().InitShake(0.5f, 0.4f);
            killFlag = true;
        }
        else
        {
            if (!collider.GetComponent<Monster>().harmless) {
                loseFlag = true;
            }
        }
    }
}