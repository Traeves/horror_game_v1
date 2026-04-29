using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class BackToMenu : MonoBehaviour
{
    public CanvasGroup fadeCanvas; // Drag your fade CanvasGroup here
    public float fadeDuration = 1f;

    public void TitleScreen()
    {
        StartCoroutine(FadeTo("MainMenu"));
    }
    public void Respawn()
    {
        StartCoroutine(FadeTo("BasicScene"));
    }

    IEnumerator FadeTo(string sceneName)
    {
        float elapsed = 0f;
        fadeCanvas.alpha = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            fadeCanvas.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}