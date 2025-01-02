using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSpawner : MonoBehaviour
{
    public enum PlayerType
    {
        Default
    }
    public PlayerType playerType;
    public GameObject[] weapons;
    public GameObject player { get; private set; }
    public ParticleSystem wallHitParticles;
    public ParticleSystem feetGroundParticles;

    public void Spawn()
    {
        player = Instantiate(weapons[(int)playerType], transform.position, Quaternion.identity, transform);
        player.GetComponent<PlayerParticles>().wallHitParticles = wallHitParticles;
        player.GetComponent<PlayerParticles>().feetGroundParticles = feetGroundParticles;

    }
}
