using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{

    Scene m_Scene;

    [HideInInspector]
    private int finishCurrentSceneCount;
    public int wood = 0;
    public int score = 0;
    public int highScore = 0;
    public string MainMenu;

    [Header ("Total collectable wood:")]
    public int woodCount;
 

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        wood = PlayerPrefs.GetInt("wood", 0);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        GetCurrentScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Debug.Log("GameStatus was destroyed.");
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("wood", wood);
        PlayerPrefs.SetInt("highScore", highScore);
    }

    public void AddScore(int s)
    {
        score += s;
    }

    public void AddWood(int w)
    {
        wood += w;
        finishCurrentSceneCount = finishCurrentSceneCount + 1;
        SetCountText();
    }

    void SetCountText()
    {
        //countText.text = "Count: " + finishCurrentSceneCount.ToString();
        if (finishCurrentSceneCount >= woodCount)
        {
            //winText.text = "You Win!";
            ResetWood();
            Debug.Log("All wood has been picked up.");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
    }

    // Resets PlayerPrefs to default when game is quit
    public void ResetScore()
    {
        score = 0;
    }

    // Resets PlayerPrefs to default when game is quit
    public void ResetWood()
    {
        wood = 0;
    }

    // Resets PlayerPrefs to default when game is quit
    public void ResetAll()
    {
        wood = 0;
        score = 0;
    }

    // Resets PlayerPrefs to default when game is quit
    public void ResetHighScore()
    {
        highScore = 0;
    }

    public void GetCurrentScene()
    {
        //Return the current Active Scene in order to get the current Scene's name
        m_Scene = SceneManager.GetActiveScene();
        //
        if (m_Scene.name == MainMenu)
        {
            Debug.Log("Current Scene: " + m_Scene.name);
        }
    }

    /*public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }*/
}