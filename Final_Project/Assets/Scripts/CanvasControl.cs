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

    void Start()
    {

    }

    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.Tab))
        {

        }*/
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

    // Level Screen
    public void ShowLevelScreen()
    {
        levelScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void HideLevelScreen()
    {
        levelScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    // Main Menu
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }
    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
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

    // Exit Game
    public void ExitGame()
    {
        Application.Quit();
    }
}
