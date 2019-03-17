using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/*void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive (false);
		}
	}*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            //score = score + 1;
            //SetCountText();
            Debug.Log("Collided with player!");
            //GameObject.GetComponent<GameStatus>().AddScore(1);
            gameStatus.AddScore(1);
        }
    }

    /*void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            //winText.text = "You Win!";
        }
    }*/
}
