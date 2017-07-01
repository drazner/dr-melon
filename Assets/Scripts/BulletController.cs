using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float lifetime;

    public int damageDone;

	// Use this for initialization
	void Start ()
    {
        //AudioSource sound = GetComponent<AudioSource>();
        //sound.Play(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Bullets should be constantly moving forward continuing in the direction they were spawned
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Destroys bullets after a given time period so that the engine isn't overloaded with objects 
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject); 
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().HurtEnemy(damageDone);
            //Debug.Log("Enemy tag acknowledged");
            Destroy(gameObject);
        }

       
            
    }
}
