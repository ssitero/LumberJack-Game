using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PickUps : MonoBehaviour
{
    [HideInInspector]
    private string currentScene;

    private void Start()
    {
        //GetCurrentScene();
    }

    public void GetCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
    }

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
            
            if (this.gameObject.name == "tutWood1")
            {
                Debug.Log("Wood");
                FindObjectOfType<GameStatus>().AddWood(1);
                FindObjectOfType<AudioManager>().Play("WoodPickup");
                FindObjectOfType<TutorialControl>().ShowShirt1();
                FindObjectOfType<CanvasControl>().SetOverlayText("Find and collect all of the flanel shirts to score points.", 5);
                
            }

            if (this.gameObject.name == "tutShirt1")
            {
                Debug.Log("Shirt");
                FindObjectOfType<GameStatus>().AddScore(1);
                FindObjectOfType<AudioManager>().Play("Pickup");
                FindObjectOfType<TutorialControl>().ShowShirt2();
                FindObjectOfType<TutorialControl>().ShowTree2();
                FindObjectOfType<CanvasControl>().SetOverlayText("Collect the last flanel shirt and pieces of wood.", 5);
            }
            this.gameObject.SetActive(false);
        }
    }
}
