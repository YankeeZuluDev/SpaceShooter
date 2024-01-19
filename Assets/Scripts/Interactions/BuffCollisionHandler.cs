using UnityEngine;
using Zenject;

/// <summary>
/// This class defines buff gameobject response to collision
/// </summary>

public class BuffCollisionHandler : MonoBehaviour, ICollisionHandler
{
    private IBuff buff;
    private BuffSpawner buffSpawner;

    [Inject]
    private void Construct(BuffSpawner buffSpawner) => this.buffSpawner = buffSpawner;

    private void Awake() => buff = GetComponent<IBuff>();

    public void HandleCollision(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerCollisionHandler playerCollisionHandler))
        {
            buffSpawner.ReleaseBuffAndSpawnNext(buff);
        }
    }
}
