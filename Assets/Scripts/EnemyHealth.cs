using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth;
    private int currentHealth;
    private bool isAlive; 

    //variables used to make the player flash colors when damaged 
    public float flashLength;
    private float flashCounter;
    private float deathCounter; 
    private Renderer rend;
    private Color storedColor;

    private AudioSource sound;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
        sound = GetComponent<AudioSource>();
        isAlive = true;

        deathCounter = 1; 
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentHealth <= 0)
        {
            if(isAlive)
                sound.Play();       //Plays sound of the enemy dying
            isAlive = false; 
            transform.Translate(new Vector3(0f, -200f, 0f));
            
        }
        
        //Since destroying the gameobject cuts off the death sound, I temporarily teleported the enemies very far downward 
        //until the death sound finishes playing and then I destroy the game object
        if(!isAlive)
        {
            deathCounter -= Time.deltaTime; 
        }
        if(deathCounter <= 0)
        {
            Destroy(gameObject);
            //Debug.Log("SUCCESS"); 
        }

        //Logic for making the enemy flash blue temporarily when they are hit by a bullet 
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
        }
        else if (flashCounter <= 0)
        {
            rend.material.SetColor("_Color", storedColor);           
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        //Debug.Log(currentHealth);

        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.blue);        


    }
}
