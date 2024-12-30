using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform target;
    public Transform obj;
    public float discount;
    public float speed;
    public abstract void face();
    public static float screenScale;
    public static float limit;
    public float spriteWidth;
    public abstract void walk();
    private int working = 1;
    public SpriteRenderer body;
    public void Kill()
    {
        //FindObjectOfType<ParticleManager>().enemyDeath(obj.position);
        //FindObjectOfType<CameraShake>().InitShake(0.75f, 0.25f);
        working = 0;
        GetComponent<BoxCollider2D>().enabled = false;
        Color color = body.color;
        color.a = 0.3f;
        body.color = color;
        StartCoroutine(ReturnSpawn());
    }
    private float returnAngle;
    private IEnumerator ReturnSpawn()
    {
        Vector3 originalPos = obj.position / screenScale;
        //Vector3 finalPos = FindObjectOfType<SpawnManager>().getSpawn(); ;
        //Vector3 delta = finalPos - originalPos;
        //Vector3 normedDelta = delta / delta.magnitude;
        Vector3 travelled = Vector3.zero;
        //returnAngle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        obj.eulerAngles = new Vector3(0f, 0f, returnAngle);
        for (int i = 0; i < 30000; i++)
        {
            //if (travelled.magnitude > delta.magnitude) { break; }
            //Vector3 move = normedDelta * Time.deltaTime * speed;
            //travelled += move;
            obj.position = (originalPos + travelled) * screenScale; 
            yield return null;
        }
        //FindObjectOfType<SpawnManager>().RequestRespawn(speed);
        Destroy(gameObject);
    }
    protected void Start()
    {
        //obj.localScale = new Vector3(1f / 9f, 1f / 9f, 1f);
        //target = FindObjectOfType<GameManager>().getSkin().transform;
    }
    protected void Update()
    {
        if (working == 1) {
            face();
            walk();
        }
    }
    public void GameOver()
    {
        speed = 0;
        returnAngle = obj.eulerAngles.z;
        working = 0;
    }
}
