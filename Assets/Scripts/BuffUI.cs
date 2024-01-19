using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// This class is responsible for handling buff UI
/// </summary>

public class BuffUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buffText;
    [SerializeField] private float easeInOutDuration;
    [SerializeField] private float waitDuration;

    private RectTransform buffTextRectTransform;

    private void Awake() => buffTextRectTransform = buffText.GetComponent<RectTransform>();

    public void ShowBuffText(string text)
    {
        buffText.text = text;

        StartCoroutine(ShowBuffTextAnimationCoroutine());
    }

    private IEnumerator ShowBuffTextAnimationCoroutine()
    {
        // Expand buff text rect transform scale from 0 to 1
        yield return buffTextRectTransform.EaseInScale(easeInOutDuration);

        // Wait
        yield return new WaitForSeconds(waitDuration);

        // Collapse buff text rect transform scale from 1 to 0
        yield return buffTextRectTransform.EaseOutScale(easeInOutDuration);
    }
}
