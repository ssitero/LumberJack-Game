using UnityEngine;
using System.Collections;

public class FPSShoot : MonoBehaviour {

	public Rigidbody projectile;
	
    [Header ("Bullet")]
	public float speed = 20;

	private AudioSource audioSource;
	public AudioClip Scored;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			audioSource = GetComponent<AudioSource>(); 
			audioSource.clip = Scored;
			audioSource.Play(); //play explosion sound

            Rigidbody bullet = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			bullet.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
            bullet.name = "Bullet";
            //bullet.AddComponent<Bullet>();
        }
	}
}
