using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public GameObject levelScreen;
    public GameObject mainMenu;
    public GameObject scorePanel;
    public GameObject pauseMenu;
    public GameObject overMenu;
    public GameObject winMenu;
    public static bool GameIsPaused = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Load Scenes
    public void LoadSceneByIndex(int buildIndex)
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    // Tutorial
    public void LoadTutorial()
    {

    }

    // Locks the game and shows the mouse
    private void LockScreen()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    // Unlocks the game and shows the mouse
    private void UnlockScreen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    // Level Screen Panel
    public void ShowLevelScreen()
    {
        levelScreen.SetActive(true);
        if (winMenu.activeInHierarchy == true)
        {
            winMenu.SetActive(false);
        }
        LockScreen();
    }
    public void HideLevelScreen()
    {
        levelScreen.SetActive(false);
        UnlockScreen();
    }

    // Over Menu Panel
    public void ShowOverMenu()
    {
        overMenu.SetActive(true);
        LockScreen();
    }
    public void HideOverMenu()
    {
        overMenu.SetActive(false);
        UnlockScreen();
    }

    // Win Menu Panel
    public void ShowWinMenu()
    {
        winMenu.SetActive(true);
        LockScreen();
    }
    public void HideWinMenu()
    {
        winMenu.SetActive(false);
        UnlockScreen();
    }

    // Main Menu Panel
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }
    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    // Pause Menu Panel
    public void Pause()
    {
        pauseMenu.SetActive(true);
        LockScreen();
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        UnlockScreen();
    }

    // Score Panel
    public void ShowScorePanel()
    {
        scorePanel.SetActive(true);
    }
    public void HideScorePanel()
    {
        scorePanel.SetActive(false);
    }

    // Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    // Exit Game
    public void ExitGame()
    {
        Application.Quit();
    }
}
