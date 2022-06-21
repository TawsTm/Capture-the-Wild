using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{

    private float fuel = 100f;
    private float currentFuel;

    private float fuelBurnrate = 20f;
    private static bool looseFuel = false;

    public Slider fuelSlider;

    private void Awake() {
        // This needs to be changed if the car should start with less then 100% fuel.
        currentFuel = 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = currentFuel / fuel;
    }

    void FixedUpdate() {
        if(looseFuel) {
            currentFuel -= fuelBurnrate * Time.deltaTime;
        }
    }

    public static void ReduceFuel(bool _looseFuel) {
        looseFuel = _looseFuel;
    }

    public static void FillUpFuel(float _amount) {
        currentFuel += _amount;
    }

    public bool IsFuelEmpty() {
        if(currentFuel <= 0) {
            return true;
        }
        return false;
    }
}
