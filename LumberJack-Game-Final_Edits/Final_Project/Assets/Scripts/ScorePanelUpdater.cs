using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUpdater : MonoBehaviour
{
    private Text woodNum;
    private Text scoreNum;

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

        woodNum = GameObject.Find("WoodNum").GetComponent<Text>();
        woodNum.text = "" + gs.wood;

        scoreNum = GameObject.Find("ScoreNum").GetComponent<Text>();
        scoreNum.text = "" + gs.score;
    }
}
