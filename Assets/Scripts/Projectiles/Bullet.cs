using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private float travelDistance;

    private BulletPool bulletPool;

    public int Damage => damage;
    public float LifeTime => lifeTime;
    public float TravelDistance => travelDistance;

    [Inject]
    private void Construct(BulletPool bulletPool) => this.bulletPool = bulletPool;

    public void StartMovingAndRotating(Vector2 direction, float speed)
    {
        StartCoroutine(MoveCoroutine(direction, speed));
    }

    public void StopMoving()
    {
        StopAllCoroutines();
        bulletPool.Pool.Release(this);
    }

    private IEnumerator MoveCoroutine(Vector2 direction, float speed)
    {
        float elapsedTime = 0f;

        while (elapsedTime < lifeTime)
        {
            // Move
            transform.Translate(direction * speed * Time.deltaTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Release bullet back to pool
        bulletPool.Pool.Release(this);
    }
}
