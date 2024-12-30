using UnityEngine;
using static Wall;

public class PlayerParticles : MonoBehaviour
{
    public ParticleSystem wallHitParticles;
    public ParticleSystem feetGroundParticles;

    public void PlayWallHitParticles(Vector2 contact, WallDirection dir)
    {
        wallHitParticles.transform.position = contact;
        wallHitParticles.transform.eulerAngles = new Vector3(0, 0, (int)dir * -90);
        wallHitParticles.Play();
    }

    public void PlayFeetGroundParticles(Vector2 contact)
    {
        feetGroundParticles.transform.position = contact;
        feetGroundParticles.Play();
    }
}
