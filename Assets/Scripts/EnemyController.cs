using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;

    public PlayerController player; 

	// Use this for initialization
	void Start ()
    {
        myRB = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Constantly trying to face towards the player 
        transform.LookAt(player.transform.position); 
	}

    private void FixedUpdate()
    {
        //Constantly moving forward and since they turn to face the player, this means they are moving towards the player
        myRB.velocity = transform.forward * moveSpeed; 
    }
}
