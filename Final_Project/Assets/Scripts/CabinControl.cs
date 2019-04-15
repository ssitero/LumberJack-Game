using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinControl : MonoBehaviour
{
    public GameObject cabinTrigger;

    void OnTriggerEnter(Collider cabinTrigger)
    {
        if (cabinTrigger.gameObject.CompareTag("Player"))
        {
            Debug.Log("At the cabin!");
            FindObjectOfType<CanvasControl>().ShowLevelScreen();
            FindObjectOfType<GameStatus>().ResetWood();
            FindObjectOfType<CanvasControl>().HideScorePanel();
        }
    }
}
