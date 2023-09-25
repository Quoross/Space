using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody Rigidbody;
    public float Thrust = 10f;
    public float RotationSpeed = 20;
    public float roll, pitch, yaw;
    
    void Start()
    {
        //Fetch the Rigidbody from the Rocket with this script attached
        Rigidbody = GetComponent<Rigidbody>();  
        Rigidbody.sleepThreshold = 0.0f; //Prevents it from sleeping (hopefully)
      
    }

  

    void Update()
    {
        roll = Input.GetAxisRaw("Horizontal") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed); 
        //seems unnecessary and i don't think its worth convoluting the controls for it
        // yaw = Input.GetAxisRaw("Vertical") * (Time.fixedDeltaTime * RotationSpeed);
        if (Rigidbody.IsSleeping())
            Rigidbody.WakeUp();
        if (Input.GetKey(KeyCode.Space))
        {
            //Apply a force to this Rigidbody in direction of Rockets up axis
            Rigidbody.AddRelativeForce(Vector3.up * Thrust);
          
        }

    }
    void FixedUpdate()
    {
        Quaternion AddRot = Quaternion.identity;
 
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        Rigidbody.rotation *= AddRot;
    }
}
