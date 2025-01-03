using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public bool gameOver { get; private set; }  = false;
    public GameObject wallHitParticle;
    public GameObject feetGroundParticle;
    InputAction reset;
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        reset = InputSystem.actions.FindAction("Reset");
        Restart();
    }

    private void Update()
    {
        if (gameOver && reset.WasPressedThisFrame())
        {
            gameOver = false;
            Restart();
        }
        if (gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Restart()
    {
        foreach (Transient t in FindObjectsByType<Transient>(FindObjectsSortMode.None))
        {
            t.DestroyMe();
        }
        PlayerSpawner playerSpawner = FindFirstObjectByType<PlayerSpawner>();
        playerSpawner.wallHitParticles = Instantiate(wallHitParticle, Vector2.zero, Quaternion.identity, transform).GetComponent<ParticleSystem>();
        playerSpawner.feetGroundParticles = Instantiate(feetGroundParticle, Vector2.zero, Quaternion.identity, transform).GetComponent<ParticleSystem>();
        playerSpawner.Spawn();
        foreach (Spawner spawner in FindObjectsByType<Spawner>(FindObjectsSortMode.None))
        {
            spawner.SpawnTillEnough();
        }

        FindFirstObjectByType<ScoreCounter>().Reset();
        Time.timeScale = 1;
    }
}
