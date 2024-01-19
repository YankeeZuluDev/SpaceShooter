using System.Collections;
using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for playing different tweens and animations related to player
/// </summary>

public class PlayerAnimationPlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private GameObject nozzleFire;

    private ExplosionPool explosionPool;
    private IInputHandler inputHandler;

    [Inject]
    private void Construct(ExplosionPool explosionPool, IInputHandler inputHandler)
    {
        this.explosionPool = explosionPool;
        this.inputHandler = inputHandler;
    }

    private void Update()
    {
        HandleNozzleFire();
    }

    public void PlayExplosionAnimation()
    {
        // Retreive explosion object from pool and play explosion animation
        Explosion explosion = explosionPool.Pool.Get();
        explosion.transform.position = transform.position;
        explosion.Explode();
    }

    public void PlayInvincibilityAnimation(float duration)
    {
        StartCoroutine(InvincibilityAnimationCoroutine(duration));
    }

    private IEnumerator InvincibilityAnimationCoroutine(float duration)
    {
        Color playerColor = playerSpriteRenderer.color;
        float initialPlayerOpacity = playerColor.a;
        float maxOpacity = 1f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            playerSpriteRenderer.color = new Color(playerColor.r, playerColor.g, playerColor.b, CalcOpacity(elapsedTime, maxOpacity));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set opacity to initial opacity
        playerSpriteRenderer.color = new Color(playerColor.r, playerColor.g, playerColor.b, initialPlayerOpacity);
    }

    public void HandleNozzleFire()
    {
        nozzleFire.SetActive(inputHandler.HasForwardInput);
    }

    private float CalcOpacity(float elapsedTime, float maxOpacity)
    {
        return Mathf.PingPong(elapsedTime * 3, maxOpacity);
    }
}
