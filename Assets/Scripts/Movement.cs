using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Rigidbody Rigidbody;

    public float Thrust = 40f;
    public float RotationSpeed = 40;
    public float roll, pitch, yaw;
    public GameObject emitter;
    private ParticleSystem partsys;
    public FuelBar fuelBar;
    public bool noFuelPower=false;
    public float burnRate = 15;
    public float fuel = 200;
    public float add_fuel = 30;
    private float currentFuel;
    private bool canThrust; //  Tests if you can fly your ship.
    public Material red, gold;
    public void Awake()
    {
        currentFuel = fuel;
        canThrust = true;
        fuelBar.setmaxfuel(fuel);
        partsys = emitter.GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider collission)
    {
        if (collission.CompareTag("Power_Up"))
        {
            collission.gameObject.SetActive(false);
            AddFuel();
        }

        if (collission.CompareTag("Golden Power"))
        {
            noFuelPower = true;
            collission.gameObject.SetActive(false);
            StartCoroutine(goldenpower());
        }
    }

    private IEnumerator goldenpower()
    {
        partsys.GetComponent<Renderer>().material = gold;
        yield return new WaitForSeconds(5);
         noFuelPower = false;
         partsys.GetComponent<Renderer>().material = red;
    }
   
    private void AddFuel()
    {
        currentFuel += add_fuel;
        currentFuel = Mathf.Clamp(currentFuel, 0, fuel); // Making sure it cant go above a certain number
    }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.sleepThreshold = 0.0f; //Prevents it from sleeping (hopefully)
    }


    private void Update()
    {
        var partsysEmission = partsys.emission;
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (!noFuelPower)
            {
                 currentFuel = currentFuel - burnRate * Time.deltaTime;
                 Debug.Log("Fuel is: " + currentFuel);
            }
        }

        if (currentFuel <= 0) canThrust = false;

        roll = Input.GetAxisRaw("Horizontal") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxisRaw("Vertical") * (Time.fixedDeltaTime * RotationSpeed);

        if (canThrust)
            if (Input.GetKey(KeyCode.Space))
            {
                //Apply a force to this Rigidbody in direction of Rockets up axis
                Rigidbody.AddRelativeForce(Vector3.up * Thrust);
                fuelBar.SetFuel(currentFuel);
                
                partsysEmission.enabled = true;
            }
            else
            {
                partsysEmission.enabled = false;
            }
        else
        {
            partsysEmission.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        var addRot = Quaternion.identity;

        addRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        Rigidbody.rotation *= addRot;
    }
}
