using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUpdater : MonoBehaviour
{
    private Text woodText;
    private Text scoreText;

    // Update is called once per frame
    private void Update()
    {
        //
        GameObject go = GameObject.Find("GameStatus");
        if(go == null)
        {
            Debug.LogError("Failed to find an object name 'GameStatus'");
            this.enabled = false;
            return;
        }

        //
        GameStatus gs = go.GetComponent<GameStatus>();
        //GetComponent<Text>().text = "Score: " + gs.score + " Wood: " + gs.wood;

        woodText = GameObject.Find("WoodText").GetComponent<Text>();
        woodText.text = "" + gs.wood;

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "" + gs.score;
    }
}
