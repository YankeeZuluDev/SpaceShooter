using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for keeping player`s screen info
/// </summary>

public class ScreenInfoKeeper : MonoBehaviour
{
    private Camera cam;
    private Vector2 screenDementions;
    private Vector2 screenDementionsWorld;
    private float halfScreenX;
    private float halfScreenY;

    public Vector2 ScreenDementions => screenDementions;
    public Vector2 ScreenDementionsWorld => screenDementionsWorld;
    public float HalfScreenX => halfScreenX;
    public float HalfScreenY => halfScreenY;

    [Inject]
    private void Construct(Camera cam)
    {
        this.cam = cam;
    }

    private void Awake() => Initialize();

    private void Initialize()
    {
        screenDementions = new Vector2(Screen.width, Screen.height);
        screenDementionsWorld = cam.ScreenToWorldPoint(screenDementions);
        halfScreenX = screenDementionsWorld.x / 2;
        halfScreenY = screenDementionsWorld.y / 2;
    }
}
