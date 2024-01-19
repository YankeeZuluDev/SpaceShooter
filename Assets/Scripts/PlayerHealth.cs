using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerAnimationPlayer))]
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Range(1, 5)]
    [SerializeField] private int maxHealth;
    [SerializeField] private GameEvent gameOverEvent;

    private UIManager uIManager;
    private AudioManager audioManager;
    private PlayerAnimationPlayer playerAnimationPlayer;
    private int currentHealth;
    private bool isInvincible;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public bool IsInvincible => isInvincible;

    [Inject]
    private void Construct(UIManager uIManager, AudioManager audioManager)
    {
        this.uIManager = uIManager;
        this.audioManager = audioManager;
    }

    private void Awake()
    {
        playerAnimationPlayer = GetComponent<PlayerAnimationPlayer>();
        SetMaxHealth();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

        audioManager.PlaySFX(AudioID.Hit);

        uIManager.UpdateHealthBarUI(maxHealth, currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        audioManager.PlaySFX(AudioID.GameOver);
        gameOverEvent?.Raise();
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;

        uIManager.UpdateHealthBarUI(maxHealth, currentHealth);
    }

    public void ApplyInvincibility(float duration)
    {
        StartCoroutine(ApplyInvincibilityCoroutine(duration));
    }

    private IEnumerator ApplyInvincibilityCoroutine(float duration)
    {
        isInvincible = true;

        playerAnimationPlayer.PlayInvincibilityAnimation(duration);

        yield return new WaitForSeconds(duration);

        isInvincible = false;
    }
}
