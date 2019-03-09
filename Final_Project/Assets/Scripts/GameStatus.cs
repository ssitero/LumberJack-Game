using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{
    //There are 3 major ways to persist this data between scenes
    // 1) Save the info into something persist (UserPrefs, a save file)
    //      - This preserves data even between game executions, not just scene changes
    //
    // 2) Static class data. This is Probably not the prefence for a beginner.
    // 3) DontDestroyOnLoad -- This flags a GameObject such that when we cahnge from one scene to another, it doesn't get destroyed. (i.e. it is still present in the newly loaded scene. To use this to the best possible advantage, you need to use the Unity Singleton Design Pattern.

    public int wood = 0;
    public int score = 0;
    public int highScore = 0;
    Scene m_Scene;
    public string MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Implementation #1
        // Load data from PlayerPrefs -- this might be from the previous
        // scene, or maybe from the previous execution
        score = PlayerPrefs.GetInt("score", 0);
        wood = PlayerPrefs.GetInt("wood", 0);
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Return the current Active Scene in order to get the current Scene's name
        m_Scene = SceneManager.GetActiveScene();
        //
        if (m_Scene.name == MainMenu)
        {
            Debug.Log("On the main menu.");
        }
    }

    private void OnDestroy()
    {
        Debug.Log("GameStatus was destroyed.");
        // Before we get destroyed, let's save our data to our save file.
        // This is "Implementation #1".
        // This will happen whenever this object is destroyed, which
        // includes scene changes as well as simply exiting the program.
        // string saveSlot = "saveSlot" + mySaveNumber;
        // PlayerPrefs.SetString("saveSlot0_inv0_logs", 10);

        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("wood", wood);
        PlayerPrefs.SetInt("highScore", highScore);
    }

    public void AddScore(int s)
    {
        score += s;
        // We could take this opportunity to save the score in a file/PlayerPrefs
        // But depending on implementation, this could be slow/inneficient.
        // On the other hand, if we are constantly saving the data on the fly,
        // it means that we pretty much never lose anything to a crash
    }

    // Resets PlayerPrefs to default when game is quit
    public void ResetScore()
    {
        score = 0;
        wood = 0;
    }

    public void GetCurrentScene()
    {
        //Debug.Log("On the main menu.");
        //Return the current Active Scene in order to get the current Scene's name
        m_Scene = SceneManager.GetActiveScene();
        //
        if (m_Scene.name == MainMenu)
        {
            Debug.Log("On the main menu.");
        }
    }


    /*public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }*/
}
