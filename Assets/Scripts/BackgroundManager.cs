using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for setting random background and scaling it to fit player`s screen
/// </summary>

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [Space()]
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private float additionalWidth;
    [SerializeField] private float additionalHeight;

    private ScreenInfoKeeper screenInfoKeeper;

    [Inject]
    private void Construct(ScreenInfoKeeper screenInfoKeeper) => this.screenInfoKeeper = screenInfoKeeper;

    private void Awake()
    {
        SetRandomBackground();
        ScaleBackground();
    }

    private void SetRandomBackground()
    {
        backgroundSpriteRenderer.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }

    private void ScaleBackground()
    {
        float screenY = screenInfoKeeper.ScreenDementionsWorld.y + additionalHeight;
        float screenX = screenInfoKeeper.ScreenDementionsWorld.x + additionalWidth;

        backgroundSpriteRenderer.size = new Vector2(screenX, screenY) * 2;
    }
}
