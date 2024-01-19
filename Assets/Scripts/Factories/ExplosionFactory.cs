using UnityEngine;
using Zenject;

public class ExplosionFactory : IFactory<GameObject, Transform, Explosion>
{
    private DiContainer container;

    [Inject]
    public ExplosionFactory(DiContainer container) => this.container = container;

    public Explosion Create(GameObject explosionPrefab, Transform parentTransform)
    {
        return container.InstantiatePrefabForComponent<Explosion>(explosionPrefab, parentTransform);
    }
}
