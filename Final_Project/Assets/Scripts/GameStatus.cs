using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{

    //Scene m_Scene;
    [HideInInspector]
    public GameObject summerCabin, autumnCabin, completeCabin;
    [HideInInspector]
    private int finishCurrentSceneCount;
    [HideInInspector]
    public int wood = 0, score = 0, highScore = 0;
    [HideInInspector]
    public string MainMenu, currentScene;
    [Header ("Total collectable wood:")]
    public int woodCount;
    [Header("Cabin to show:")]
    public string cabinName;


    // Start is called before the first frame update
    void Start()
    {
        GetCurrentScene();

        score = PlayerPrefs.GetInt("score", 0);
        wood = PlayerPrefs.GetInt("wood", 0);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        Time.timeScale = 1f;

        // Hide all cabins initially
        summerCabin = GameObject.Find("SummerCabin");
        autumnCabin = GameObject.Find("AutumnCabin");
        completeCabin = GameObject.Find("CompleteCabin");
        if (summerCabin != null)
        {
            summerCabin.SetActive(false);
        }
        if (autumnCabin != null)
        {
            autumnCabin.SetActive(false);
        }
        if (autumnCabin != null)
        {
            completeCabin.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // FOR TESTING //
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowCabin("Summer");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowCabin("Autumn");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowCabin("Complete");
        }
        /////////////////
    }

    public void GetCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        Debug.Log("Active Scene is '" + currentScene + "'.");

        //return currentScene;
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
            //FindObjectOfType<CanvasControl>().ShowWinMenu();
            FindObjectOfType<CanvasControl>().SetOverlayText("Enter the Cabin.", 3);
            FindObjectOfType<CanvasControl>().HideScorePanel();    
            ResetWood();
            ShowCabin(cabinName);
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

    public void ShowCabin(string cabin)
    {
        print("Cabin name: " + cabin);
        switch (cabin)
        {
            case "Summer":
                summerCabin.SetActive(true);
                break;
            case "Autumn":
                autumnCabin.SetActive(true);
                break;
            case "Complete":
                completeCabin.SetActive(true);
                break;
            default:
                print("No cabin");
                break;
        }
    }
}