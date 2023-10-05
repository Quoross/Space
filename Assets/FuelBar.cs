using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider Fuelbar;

    public void setmaxfuel(float fuel)
    {
        Fuelbar.maxValue = fuel;
        Fuelbar.value = fuel;
    }
    public void SetFuel(float fuel)
    {
        Fuelbar.value = fuel;
    }
 
}
