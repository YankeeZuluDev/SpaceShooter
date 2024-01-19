using System.Collections;
using UnityEngine;

public static class Tweens
{
    public static IEnumerator Shake(this Transform t, float duration)
    {
        Vector3 originalPosition = t.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float randomX =  Random.Range(-0.05f, 0.05f);
            float randomY = Random.Range(-0.05f, 0.05f);

            t.localPosition = new Vector3(randomX, randomY, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        t.localPosition = originalPosition;
    }

    /// <summary>
    /// Expand rect transform scale
    /// </summary>
    public static IEnumerator EaseInScale(this RectTransform rectTransform, float duration)
    {
        yield return EaseScale(rectTransform, duration, Vector2.one);
    }

    /// <summary>
    /// Collapse rect transform scale
    /// </summary>
    public static IEnumerator EaseOutScale(this RectTransform rectTransform, float duration)
    {
        yield return EaseScale(rectTransform, duration, Vector2.zero);
    }

    private static IEnumerator EaseScale(RectTransform rectTransform, float duration, Vector2 targetScale)
    {
        Vector2 initialScale = rectTransform.localScale;

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            rectTransform.localScale = Vector2.Lerp(initialScale, targetScale, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = targetScale;
    }
}
