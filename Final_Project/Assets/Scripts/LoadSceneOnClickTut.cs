using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClickTut : MonoBehaviour
{
    public void LoadByIndex(int buildIndex)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());


    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
