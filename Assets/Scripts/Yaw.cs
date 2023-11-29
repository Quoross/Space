using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Yaw : MonoBehaviour
{
    Rigidbody Rigidbody;
   
    public float RotationSpeed = 5;
    public float roll, pitch, yaw;
    void Update()
    {
        roll = Input.GetAxisRaw("Horizontal") * (Time.fixedDeltaTime * RotationSpeed);
        //pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxisRaw("Vertical") * (Time.fixedDeltaTime * RotationSpeed);
    }
    
    void FixedUpdate()
    {
        Quaternion AddRot = Quaternion.identity;
 
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        Rigidbody.rotation *= AddRot;
    }
}
