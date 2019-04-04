using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletLife = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        bulletLife -= Time.deltaTime;
        if (bulletLife < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LargeRoom")
        {
            print("Wall hit!");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Hallway1")
        {
            print("Wall hit!");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SmallRoom")
        {
            print("Wall hit!");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Hallway2")
        {
            print("Wall hit!");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "LargeRoomFloor")
        {
            print("Ground hit!");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "HallwayFloor")
        {
            print("Ground hit!");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "SmallRoomFloor")
        {
            print("Ground hit!");
            Destroy(this.gameObject);
        }
    }
}
