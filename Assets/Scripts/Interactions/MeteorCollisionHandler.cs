using UnityEngine;
using Zenject;

/// <summary>
/// This class defines meteor gameobject response to collision
/// </summary>

public class MeteorCollisionHandler : MonoBehaviour, ICollisionHandler
{
    private IProjectile meteor;
    private ExplosionPool explosionPool;
    private AudioManager audioManager;

    [Inject]
    private void Construct(ExplosionPool explosionPool, AudioManager audioManager)
    {
        this.explosionPool = explosionPool;
        this.audioManager = audioManager;
    }

    private void Awake() => meteor = GetComponent<IProjectile>();

    public void HandleCollision(Collider2D collision)
    {
        // If collision is IProjectile or IDamageable
        if (collision.GetComponent<IProjectile>() != null || collision.GetComponent<IDamageable>() != null)
        {
            DestroyMeteorAndExplode();
        }
    }

    private void DestroyMeteorAndExplode()
    {
        // Destroy meteor
        meteor.StopMoving();

        // Retreive explosion object and play explosion animation
        Explosion explosion = explosionPool.Pool.Get();
        explosion.transform.position = transform.position;
        explosion.Explode();

        // Play explosion sound
        audioManager.PlaySFX(AudioID.Explosion);
    }
}
