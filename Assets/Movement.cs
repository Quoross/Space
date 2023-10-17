using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody Rigidbody;

    public float Thrust = 40f;
    public float RotationSpeed = 40;
    public float roll, pitch, yaw;

    public FuelBar fuelBar;

    public float burnRate = 15;
    public float fuel = 200;
    public float add_fuel = 30;
    private float currentFuel;
    private bool canThrust; //  Tests if you can fly your ship.

    public void Awake()
    {
        currentFuel = fuel;
        canThrust = true;
        fuelBar.setmaxfuel(fuel);
    }


    private void OnTriggerEnter(Collider Fuel)
    {
        if (Fuel.CompareTag("Power_Up"))
        {
            Fuel.gameObject.SetActive(false);
            AddFuel();
        }
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
        if (Input.GetKey(KeyCode.Space))
        {
            currentFuel = currentFuel - burnRate * Time.deltaTime;
            Debug.Log("Fuel is: " + currentFuel);
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
            }
    }

    private void FixedUpdate()
    {
        var addRot = Quaternion.identity;

        addRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        Rigidbody.rotation *= addRot;
    }
}
