using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Meteor : MonoBehaviour, IProjectile
{
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private float travelDistance;
    [SerializeField] private Transform meteorSpriteTransform;
    [SerializeField] private SpriteRenderer meteorSpriteRenderer;
    [SerializeField] private int scorePerMeteor;

    private MeteorPool meteorPool;
    private Coroutine moveCorouine;
    private float rotationSpeed;

    public int Damage => damage;
    public float LifeTime => lifeTime;
    public float TravelDistance => travelDistance;
    public int ScorePerMeteor => scorePerMeteor;
    public SpriteRenderer MeteorSpriteRenderer => meteorSpriteRenderer;

    [Inject]
    private void Construct(MeteorPool meteorPool) => this.meteorPool = meteorPool;

    public void StartMovingAndRotating(Vector2 direction, float speed)
    {
        moveCorouine = StartCoroutine(MoveAndRotateCoroutine(direction, speed));
    }

    public void StopMoving()
    {
        StopCoroutine(moveCorouine);
        meteorPool.Pool.Release(this);
    }

    public void SetRotationSpeed(float rotationSpeed) => this.rotationSpeed = rotationSpeed;

    private IEnumerator MoveAndRotateCoroutine(Vector2 direction, float speed)
    {
        float elapsedTime = 0f;

        while (elapsedTime < lifeTime)
        {
            // Move
            transform.Translate(speed * Time.deltaTime * direction);

            // Rotate meteor sprite
            meteorSpriteTransform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        StopMoving();
    }
}
