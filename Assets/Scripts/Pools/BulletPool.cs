using UnityEngine;
using UnityEngine.Pool;
using Zenject;

/// <summary>
/// An object pool for bullets
/// </summary>

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private ObjectPool<Bullet> pool;
    private BulletFactory bulletFactory;

    public ObjectPool<Bullet> Pool => pool;

    [Inject]
    private void Construct(BulletFactory bulletFactory)
    {
        this.bulletFactory = bulletFactory;
    }

    private void Awake()
    {
        pool = new ObjectPool<Bullet>(
            () => bulletFactory.Create(bulletPrefab, transform), 
            OnGet, 
            OnRelease, 
            OnKill, 
            false,
            5,
            20);
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnKill(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
