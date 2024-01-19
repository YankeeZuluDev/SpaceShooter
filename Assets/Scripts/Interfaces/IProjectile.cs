using UnityEngine;

/// <summary>
/// An interface for projectile
/// </summary>

public interface IProjectile
{
    int Damage { get; }
    float LifeTime { get; }
    float TravelDistance { get; }
    void StartMovingAndRotating(Vector2 direction, float speed);
    void StopMoving();
}
