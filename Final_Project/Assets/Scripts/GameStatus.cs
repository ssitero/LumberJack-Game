using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{

    //Scene m_Scene;

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
        Time.timeScale = 1f;
        //GetCurrentScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 
    private void OnDestroy()
    {
        Debug.Log("GameStatus was destroyed.");
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("wood", wood);
        PlayerPrefs.SetInt("highScore", highScore);
    }

    // Add to the score
    public void AddScore(int s)
    {
        score += s;
    }

    // Add to the wood count
    public void AddWood(int w)
    {
        wood += w;
        finishCurrentSceneCount = finishCurrentSceneCount + 1;
        SetCountText();
    }

    // When all the wood is collected reset the wood count to 0 and show/hide panels
    void SetCountText()
    {
        if (finishCurrentSceneCount >= woodCount)
        {
            Debug.Log("All wood has been picked up.");
            FindObjectOfType<CanvasControl>().ShowWinMenu();
            FindObjectOfType<CanvasControl>().HideScorePanel();    
            ResetWood();
        }
    }

    // Resets PlayerPrefs to 0 when game is quit
    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        score = 0;
    }

    // Resets PlayerPrefs to 0 when game is quit
    public void ResetWood()
    {
        PlayerPrefs.SetInt("wood", 0);
        wood = 0;
    }

    // Resets PlayerPrefs to 0 when game is quit
    public void ResetAll()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("wood", 0);
        wood = 0;
        score = 0;
    }

    // Resets PlayerPrefs to 0 when game is quit
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScore = 0;
    }

    private void OnApplicationQuit()
    {
        ResetAll();
    }
}