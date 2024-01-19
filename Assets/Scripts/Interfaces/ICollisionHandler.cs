using UnityEngine;

/// <summary>
/// An interface for collision handler
/// </summary>

public interface ICollisionHandler
{
    void HandleCollision(Collider2D collision);
}
