using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
         if (other.gameObject.CompareTag("Player"))
        {
           

           // if (this.gameObject.tag == "Tree")
           // {
                this.gameObject.SetActive(false);
            }
            
        }
}
