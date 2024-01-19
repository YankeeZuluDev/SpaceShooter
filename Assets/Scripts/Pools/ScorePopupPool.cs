using UnityEngine;
using UnityEngine.Pool;
using Zenject;

/// <summary>
/// An object pool for score popups
/// </summary>

public class ScorePopupPool : MonoBehaviour
{
    [SerializeField] private GameObject scorePopupPrefab;

    private ObjectPool<ScorePopup> pool;
    private UIManager uIManager;

    public ObjectPool<ScorePopup> Pool => pool;
    private ScorePopupFactory scorePopupFactory;

    [Inject]
    private void Construct(UIManager uIManager, ScorePopupFactory scorePopupFactory)
    {
        this.uIManager = uIManager;
        this.scorePopupFactory = scorePopupFactory;
    }

    private void Awake()
    {
        pool = new ObjectPool<ScorePopup>(
            () => scorePopupFactory.Create(scorePopupPrefab, uIManager.Canvas.transform),
            OnGet,
            OnRelease,
            OnKill,
            false,
            5,
            20);
    }

    private void OnGet(ScorePopup scorePopup)
    {
        scorePopup.gameObject.SetActive(true);
    }

    private void OnRelease(ScorePopup scorePopup)
    {
        scorePopup.gameObject.SetActive(false);
    }

    private void OnKill(ScorePopup scorePopup)
    {
        Destroy(scorePopup.gameObject);
    }
}
