using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Collided with pickup!");
            //gameStatus.GetComponent<GameStatus>().AddScore(1);
            //gameStatus.AddScore(1);
          
            if (this.gameObject.tag == "Coin")
            {
                Debug.Log("Coin");
                FindObjectOfType<GameStatus>().AddScore(1);
            }

            if (this.gameObject.tag == "Wood")
            {
                Debug.Log("Wood");
                FindObjectOfType<GameStatus>().AddWood(1);
            }
            this.gameObject.SetActive(false);
        }
    }
}
