using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController gun; 

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>(); 
    }

    // Update is called once per frame. Update loop happens at variable time 
    void Update()
    {
        // **************GetAxisRaw makes the object much more responsive to input than GetAxis************** 
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Creates a line pointing from the camera to where the mouse is 
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))      //If the ray coming from the camera hits something 
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            //Draws a line pointing from the camera to the mouse  
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Input.GetMouseButtonDown(0)) //If you are left clicking
            gun.isFiring = true;
        if (Input.GetMouseButtonUp(0))
            gun.isFiring = false; 
        
    }

    //Fixed update happens at a set rate. Every .02 seconds 
    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
