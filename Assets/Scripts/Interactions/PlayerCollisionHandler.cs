using UnityEngine;
using Zenject;

/// <summary>
/// This class defines player response to collision
/// </summary>

[RequireComponent(typeof(PlayerBuffHandler))]

public class PlayerCollisionHandler : MonoBehaviour, ICollisionHandler
{
    [SerializeField] private float cameraShakeDuration;

    private IDamageable damageable;
    private Camera cam;
    private PlayerBuffHandler playerBuffHandler;

    [Inject]
    private void Construct(Camera cam) => this.cam = cam;

    private void Awake()
    {
        damageable = GetComponent<IDamageable>();
        playerBuffHandler = GetComponent<PlayerBuffHandler>();
    }

    public void HandleCollision(Collider2D collision)
    {
        if (collision.TryGetComponent(out IProjectile projectile))
        {
            // Shake camera
            StartCoroutine(cam.transform.Shake(cameraShakeDuration));

            // Take damage
            damageable.TakeDamage(projectile.Damage);
        }

        if (collision.TryGetComponent(out IBuff buff))
        {
            playerBuffHandler.Buff(buff);
        }
    }
}
