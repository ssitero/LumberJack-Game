using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Collided with pickup!");
            //gameStatus.GetComponent<GameStatus>().AddScore(1);
            //gameStatus.AddScore(1);

            if (this.gameObject.tag == "Shirt")
            {
                Debug.Log("Shirt");
                FindObjectOfType<GameStatus>().AddScore(1);
                FindObjectOfType<AudioManager>().Play("Pickup");
            }

            if (this.gameObject.tag == "Wood")
            {
                Debug.Log("Wood");
                FindObjectOfType<GameStatus>().AddWood(1);
                FindObjectOfType<AudioManager>().Play("WoodPickup");
            }
            this.gameObject.SetActive(false);
        }
    }
}
