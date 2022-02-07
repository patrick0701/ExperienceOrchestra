using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] InputActionProperty menuButtonProperty;

    public bool isGamePaused = false;

    private void Start()
    {
        menuButtonProperty.action.performed += HandlePause;
    }

    private void HandlePause(CallbackContext context)
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuUI");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
