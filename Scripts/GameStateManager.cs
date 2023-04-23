using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public bool IsGamePaused => Time.timeScale == 0f;
    public int ActiveSceneIndex => SceneManager.GetActiveScene().buildIndex;

    public event Action GamePaused;
    public event Action GameUnpaused;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game was paused");
        GamePaused?.Invoke();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game was unpaused");
        GameUnpaused?.Invoke();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitApplication()
    {
        Debug.Log("QuitApplication");
        Application.Quit();
    }
}