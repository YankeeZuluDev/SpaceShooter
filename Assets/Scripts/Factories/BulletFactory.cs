using UnityEngine;
using Zenject;

public class BulletFactory : IFactory<GameObject, Transform, Bullet>
{
    private DiContainer container;

    public BulletFactory(DiContainer container) => this.container = container;

    public Bullet Create(GameObject bulletPrefab, Transform parentTransform)
    {
        return container.InstantiatePrefabForComponent<Bullet>(bulletPrefab, parentTransform);
    }
}
