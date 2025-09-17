using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BlinkFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 0.2f;

    public IEnumerator DoBlink(Action duringBlackout)
    {
        // Fade Out
        yield return Fade(0f, 1f);

        // Exécuter la téléportation pendant l’écran noir
        duringBlackout?.Invoke();

        // Petit délai (optionnel)
        yield return new WaitForSeconds(0.05f);

        // Fade In
        yield return Fade(1f, 0f);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color c = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);
            c.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = c;
            yield return null;
        }

        c.a = endAlpha;
        fadeImage.color = c;
    }
}
