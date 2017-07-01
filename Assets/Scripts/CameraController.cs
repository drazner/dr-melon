using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController player;

    private Vector3 offset;
    private bool highCam;  

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
        highCam = true; 
	}

    private void Update()
    {
        //if(Input.GetKeyDown("C"))       //Toggles the camera between high and low orientation, couldn't figure it out 
        //{
        //    highCam = !highCam; 
        //    if(highCam)
        //    {
        //        transform.position = new Vector3(0f,5f,-10f);
        //        transform.Rotate(new Vector3(25f, 0f, 0f)); 
                
        //    }
        //    else
        //    {
        //        transform.position = new Vector3(0f, 15f,-3.56f);
        //        transform.Rotate(new Vector3(75f, 0f, 0f));
        //    }
        //}
    }

    // LateUpdate makes it happpen last out of all the frame updates 
    void LateUpdate ()
    {
        transform.position = player.transform.position + offset; 
	}
}
