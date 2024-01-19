using UnityEngine;
using Zenject;

public class ScorePopupFactory : IFactory<GameObject, Transform, ScorePopup>
{
    private DiContainer container;

    [Inject]
    public ScorePopupFactory(DiContainer container) => this.container = container;

    public ScorePopup Create(GameObject scorePopupPrefab, Transform parentTransform)
    {
        return container.InstantiatePrefabForComponent<ScorePopup>(scorePopupPrefab, parentTransform);
    }
}
