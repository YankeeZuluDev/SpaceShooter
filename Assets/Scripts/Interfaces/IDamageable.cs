/// <summary>
/// An interface for damageable
/// </summary>

public interface IDamageable
{
    int MaxHealth { get; }
    int CurrentHealth { get; }
    void TakeDamage(int damage);
    void Die();
}
