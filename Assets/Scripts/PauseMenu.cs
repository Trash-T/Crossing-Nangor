using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
