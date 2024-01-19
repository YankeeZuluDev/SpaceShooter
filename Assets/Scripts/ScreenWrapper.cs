using UnityEngine;
using Zenject;

/// <summary>
/// This class allows a game object to wrap around the screen when it goes off the screen
/// </summary>

public class ScreenWrapper : MonoBehaviour
{
    [SerializeField] private float screenToBoundaryOffset;

    private ScreenInfoKeeper screenInfoKeeper;
    private float warpOffset;
    private float xBoundary;
    private float yBoundary;

    [Inject]
    private void Construct(ScreenInfoKeeper screenInfoKeeper) => this.screenInfoKeeper = screenInfoKeeper;

    private void Awake()
    {
        xBoundary = screenInfoKeeper.ScreenDementionsWorld.x + screenToBoundaryOffset;
        yBoundary = screenInfoKeeper.ScreenDementionsWorld.y + screenToBoundaryOffset;

        warpOffset = screenToBoundaryOffset / 2f;
    }

    private void Update()
    {
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector2(-transform.position.x + warpOffset, transform.position.y);
        }

        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector2(-transform.position.x - warpOffset, transform.position.y);
        }

        if (transform.position.y > yBoundary)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y + warpOffset);
        }

        if (transform.position.y < -yBoundary)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y - warpOffset);
        }
    }
}
