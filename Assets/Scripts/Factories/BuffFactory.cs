using UnityEngine;
using Zenject;

public class BuffFactory : IFactory<GameObject, Transform, IBuff>
{
    private DiContainer container;

    [Inject]
    public BuffFactory(DiContainer container) => this.container = container;

    public IBuff Create(GameObject buffPrefab, Transform parentTransform)
    {
        return container.InstantiatePrefabForComponent<IBuff>(buffPrefab, parentTransform);
    }
}
