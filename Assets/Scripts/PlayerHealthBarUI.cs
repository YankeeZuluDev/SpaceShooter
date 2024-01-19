using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for handling player health bar UI
/// </summary>

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image healthBarFillImage;

    public void UpdateHealthBarUI(int maxHealth, int health)
    {
        if (health < 0) return;

        healthBarFillImage.fillAmount = health / (float)maxHealth;
    }
}
