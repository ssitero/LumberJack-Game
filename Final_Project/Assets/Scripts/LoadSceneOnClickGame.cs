using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClickGame : MonoBehaviour
{
    //Test

    public void LoadByIndex(int buildIndex)
    {

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());


    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
