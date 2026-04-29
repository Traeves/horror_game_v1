using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuCanvas;
    public float menuDistance = 1.5f;
    public Transform xrCamera;

    [Header("Input")]
    public InputActionReference pauseAction;

    private bool isPaused = false;

    void OnEnable() => pauseAction.action.performed += _ => TogglePause();
    void OnDisable() => pauseAction.action.performed -= _ => TogglePause();

    void Start()
    {
        if (xrCamera == null)
            xrCamera = Camera.main.transform;

        pauseMenuCanvas.SetActive(false);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused) Pause();
        else Resume();
    }

    void Pause()
    {
        Vector3 spawnPos = xrCamera.position + xrCamera.forward * menuDistance;
        spawnPos.y = xrCamera.position.y;
        pauseMenuCanvas.transform.position = spawnPos;
        pauseMenuCanvas.transform.LookAt(xrCamera.position);
        pauseMenuCanvas.transform.Rotate(0f, 180f, 0f);

        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnResumePressed()
    {
        isPaused = false;
        Resume();
    }

    public void OnQuitPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRestartPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}