using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{

    private float fuel = 100f;
    private static float currentFuel;

    private float fuelBurnrate = 2f;
    private static bool looseFuel = false;

    public Slider fuelSlider;

    List<FuelTank> m_FuelTanks = new List<FuelTank>();

    public List<FuelTank> FuelTanks => m_FuelTanks;

    public static Action<FuelTank> RegisterFuelTank;

    private void Awake() {
        // This needs to be changed if the car should start with less then 100% fuel.
        currentFuel = 100f;
    }

    public void OnEnable() {
        RegisterFuelTank += OnRegisterFuelTank;
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

    public void OnRegisterFuelTank(FuelTank fuelTank)
    {
        m_FuelTanks.Add(fuelTank);
    }
}
