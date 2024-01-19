using UnityEngine;
using Zenject;

/// <summary>
/// This class defines bullet gameobject response to collision
/// </summary>

public class BulletCollisionHandler : MonoBehaviour, ICollisionHandler
{
    private Camera cam;
    private ScorePopupPool scorePopupPool;
    private IProjectile bullet;
    private UIManager uIManager;
    private ScoreManager scoreManager;

    [Inject]
    private void Construct(ScoreManager scoreManager, ScorePopupPool scorePopupPool, UIManager uIManager, Camera cam)
    {
        this.cam = cam;
        this.scorePopupPool = scorePopupPool;
        this.uIManager = uIManager;
        this.scoreManager = scoreManager;
    }

    private void Awake() => bullet = GetComponent<IProjectile>();

    public void HandleCollision(Collider2D collision)
    {
        if (collision.TryGetComponent(out Meteor meteor))
        {
            scoreManager.AddScore(meteor.ScorePerMeteor);

            // Show text above destroyed meteor
            ShowMeteorScoreText(meteor.transform.position, meteor.ScorePerMeteor);
        }

        if (collision.TryGetComponent(out IProjectile projectile))
        {
            bullet.StopMoving();
        }
    }

    private void ShowMeteorScoreText(Vector2 meteorPostion, int score)
    {
        // Get meteor text object from pool
        ScorePopup meteorScorePopup = scorePopupPool.Pool.Get();

        // Set text to score value
        meteorScorePopup.Text.text = score.ToString();

        // Set text object position
        meteorScorePopup.RectTransform.anchoredPosition = WorldToCanvasPoint(meteorPostion);

        // Play text fade out animation
        meteorScorePopup.FadeOutText();
    }

    private Vector2 WorldToCanvasPoint(Vector2 pos)
    {
        Vector2 screenPoint = cam.WorldToScreenPoint(pos);

        return screenPoint - uIManager.CanvasRectTransform.sizeDelta / 2f;
    }
}
