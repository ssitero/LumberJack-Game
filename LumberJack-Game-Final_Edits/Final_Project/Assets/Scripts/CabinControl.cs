using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CabinControl : MonoBehaviour
{
    public GameObject cabinTrigger;
    [HideInInspector]
    public string currentScene;

    private void Start()
    {
        SetCurrentScene();
        //currentScene = FindObjectOfType<GameStatus>().GetCurrentScene();
    }

    public void SetCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        Debug.Log("Active Scene is '" + currentScene + "'.");
    }

    void OnTriggerEnter(Collider cabinTrigger)
    {
        if (currentScene != "LevelThree" && cabinTrigger.gameObject.CompareTag("Player"))
        {
            Debug.Log("At the cabin!");
            FindObjectOfType<CanvasControl>().ShowLevelScreen();
            FindObjectOfType<GameStatus>().ResetWood();
            FindObjectOfType<CanvasControl>().HideScorePanel();
        }
        if (currentScene == "LevelThree" && cabinTrigger.gameObject.CompareTag("Player"))
        {
            Debug.Log("At the cabin!");
            FindObjectOfType<CanvasControl>().ShowWinMenu();
            FindObjectOfType<CanvasControl>().HideScorePanel();
            FindObjectOfType<GameStatus>().ResetAll();
        }
    }
}
