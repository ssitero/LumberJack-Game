using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    GameObject levelScreen;

    void Start()
    {
        //levelScreen = GameObject.Find("LevelScreen");
        //Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            //levelScreen.SetActive(false);
            //Time.timeScale = 1f;
        }
    }

    public void LoadByIndex(int buildIndex)
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void LoadTutorial()
    {

    }

    public void ShowLevelScreen()
    {

    }

    public void HideLevelScreen()
    {
        //levelScreen.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
