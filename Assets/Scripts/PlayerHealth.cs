using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    private int currentHealth;

    //variables used to make the player flash colors when damaged 
    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;
    private AudioSource sound;

    public GameObject healthBar; 

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>(); 
        storedColor = rend.material.GetColor("_Color");
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(currentHealth <= 0)
        {
            //gameObject.SetActive(false);
            SceneManager.LoadScene("Demo");
        }

        //This is the logic which allows the player to flash red and then revert back to the original color after taking damage 
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;                           
        }
        if(flashCounter <= 0)
        {
            rend.material.SetColor("_Color", storedColor); 
        }

        SetHealthBar(); 
	}

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current health: " + currentHealth);

        flashCounter = flashLength;

        rend.material.SetColor("_Color", Color.red);        //Sets the player to red temporarily to denote damage was taken 
        sound.Play();                                       //Plays the sound effect for the player taking damage
    }

    public void SetHealthBar()
    {
        float myHealth = ((float)currentHealth) / maxHealth;
        //Debug.Log("currentHealth: " + currentHealth + "myHealth: " + myHealth);
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z); 
    }
}
