using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 1f;

    public Transform SpawnPoint; 

	// Use this for initialization
	void Start ()
    {
        //2nd Parameter: the time between the game starting and the first enemy spawning
        //3rd Parameter: the time between successive spawns following the first one 
        InvokeRepeating("Spawn", 5, spawnTime); 
	}
	
	void Spawn()
    {
        //Spawns enemies at random locations on the XZ plane  
        float randX = Random.Range(-21, 21);
        float randZ = Random.Range(-21, 21);
        Instantiate(enemy, new Vector3(randX, 1f, randZ), SpawnPoint.rotation);
        
    }
}
