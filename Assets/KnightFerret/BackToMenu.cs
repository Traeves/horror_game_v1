using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
