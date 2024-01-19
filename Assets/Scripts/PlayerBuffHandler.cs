using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for applying buffs for player
/// </summary>

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerWeapon))]

public class PlayerBuffHandler : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerWeapon playerWeapon;
    private UIManager uIManager;
    private AudioManager audioManager;

    private string invincibilityBuffText = "Invincibility!";
    private string fireRateUpBuffText = "Fire Rate Up!";

    [Inject]
    private void Construct(UIManager uIManager, AudioManager audioManager)
    {
        this.uIManager = uIManager;
        this.audioManager = audioManager;
    }

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerWeapon = GetComponent<PlayerWeapon>();
    }

    public void Buff(IBuff buff)
    {
        switch (buff)
        {
            case InvincibilityBuff invincibilityBuff:
                Buff(invincibilityBuff);
                break;
            case FireRateUpBuff fireRateUpBuff:
                Buff(fireRateUpBuff);
                break;
        }
    }

    /// <summary>
    /// Apply invincibility buff
    /// </summary>
    private void Buff(InvincibilityBuff invincibilityBuff)
    {
        if (playerHealth.IsInvincible) return;

        uIManager.ShowBuffText(invincibilityBuffText);

        audioManager.PlaySFX(AudioID.Buff);

        playerHealth.ApplyInvincibility(invincibilityBuff.Duration);

    }

    /// <summary>
    /// Apply fire rate up buff
    /// </summary>
    private void Buff(FireRateUpBuff fireRateUpBuff)
    {
        if (playerWeapon.IsFireRateBuffed) return;

        uIManager.ShowBuffText(fireRateUpBuffText);

        audioManager.PlaySFX(AudioID.Buff);

        playerWeapon.ApplyFireRateUpBuff(fireRateUpBuff.FireRateAmount, fireRateUpBuff.Duration);
    }
}
