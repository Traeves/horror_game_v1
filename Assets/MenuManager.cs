using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;

    public void StartGame()
    {
        Debug.Log("START BUTTON ACTIVATED!");
        StartCoroutine(FadeTo("BasicScene"));
    }
    public void OpenCredits()
    {
        Debug.Log("Credits Clicked!");
        StartCoroutine(FadeTo("Credits"));
    }
    public void QuitGame()
    {
        Debug.Log("Quit Clicked!");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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