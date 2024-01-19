using UnityEngine;
using Zenject;

public class MeteorFactory : IFactory<GameObject, Transform, Meteor>
{
    private DiContainer container;

    [Inject]
    public MeteorFactory(DiContainer container) => this.container = container;

    public Meteor Create(GameObject meteorPrefab, Transform parentTransform)
    {
        return container.InstantiatePrefabForComponent<Meteor>(meteorPrefab, parentTransform);
    }
}
