using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(RectTransform))]

public class ScorePopup : MonoBehaviour
{
    [SerializeField] private float fadeOutMoveSpeed;
    [SerializeField] private float fadeOutDuration;

    private TextMeshProUGUI text;
    private RectTransform rectTransform;
    private ScorePopupPool textPool;

    public TextMeshProUGUI Text => text;
    public RectTransform RectTransform => rectTransform;

    [Inject]
    private void Construct(ScorePopupPool textPool) => this.textPool = textPool;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void FadeOutText() => StartCoroutine(FadeOutTextCoroutine());

    private IEnumerator FadeOutTextCoroutine()
    {
        float initialOpacity = text.alpha;
        float targetOpacity = 0;

        float elapsedTime = 0;

        while (elapsedTime < fadeOutDuration)
        {
            // Fade out text position
            rectTransform.Translate(Time.deltaTime * fadeOutDuration * Vector2.up);

            // Fade out text opacity
            text.alpha = Mathf.Lerp(initialOpacity, targetOpacity, elapsedTime / fadeOutDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Set opacity to initial opacity
        text.alpha = initialOpacity;

        // Return to pool
        textPool.Pool.Release(this);
    }
}
