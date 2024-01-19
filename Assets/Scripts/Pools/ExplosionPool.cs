using UnityEngine;
using UnityEngine.Pool;
using Zenject;

/// <summary>
/// An object pool for explosions
/// </summary>

public class ExplosionPool : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    private ObjectPool<Explosion> pool;
    private ExplosionFactory explosionFactory;

    public ObjectPool<Explosion> Pool => pool;

    [Inject]
    private void Construct(ExplosionFactory explosionFactory) => this.explosionFactory = explosionFactory;

    private void Awake()
    {
        pool = new ObjectPool<Explosion>(
            () => explosionFactory.Create(explosionPrefab, transform),
            OnGet,
            OnRelease,
            OnKill,
            false, 
            2, 
            10);
    }

    private void OnGet(Explosion explosion)
    {
        explosion.gameObject.SetActive(true);
    }

    private void OnRelease(Explosion explosion)
    {
        explosion.gameObject.SetActive(false);
    }

    private void OnKill(Explosion explosion)
    {
        Destroy(explosion.gameObject);
    }
}
