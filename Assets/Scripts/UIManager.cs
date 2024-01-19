using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for initializing the canvas and updating UI
/// </summary>

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private BuffUI buffUI;
    [SerializeField] private PlayerHealthBarUI playerHealthBarUI;
    [SerializeField] private float canvasPlaneDistance;

    private Camera cam;
    private RectTransform canvasRectTransform;

    public Canvas Canvas => canvas;
    public RectTransform CanvasRectTransform => canvasRectTransform;

    [Inject]
    private void Construct(Camera cam) => this.cam = cam;

    private void Awake()
    {
        SetCanvasCamera();
        SetPlaneDistance();

        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    private void SetCanvasCamera() => canvas.worldCamera = cam;

    private void SetPlaneDistance() => canvas.planeDistance = canvasPlaneDistance;

    public void UpdateScoreUI(int score) => scoreUI.UpdateScoreUI(score);

    public void UpdateMaxScoreUI(int maxScore) => scoreUI.UpdateMaxScoreUI(maxScore);

    public void UpdateHealthBarUI(int maxHealth, int health) => playerHealthBarUI.UpdateHealthBarUI(maxHealth, health);

    public void ShowBuffText(string text) => buffUI.ShowBuffText(text);
}
