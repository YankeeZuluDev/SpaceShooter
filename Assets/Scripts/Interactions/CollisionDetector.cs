using UnityEngine;

/// <summary>
/// This class allows gameobject to detect collisions 
/// </summary>

[RequireComponent(typeof(BoxCollider2D))]

public class CollisionDetector : MonoBehaviour
{
    private ICollisionHandler collisionHandler;

    private void Awake() => collisionHandler = GetComponent<ICollisionHandler>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionHandler.HandleCollision(collision);
    }
}
