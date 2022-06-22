using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour
{
    [Tooltip("Layers to trigger with")]
    public LayerMask layerMask;

    public float fillUpSpeed = 5f;
    private bool entered;
    // Start is called before the first frame update
    void Start()
    {
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FillUp(float delay) {
        while (entered) {
            yield return new WaitForSeconds(delay);
            PumpGas();
        }
    }

    void PumpGas() {
        FuelManager.FillUpFuel(fillUpSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
        {
            entered = true;
            StartCoroutine("FillUp", .1f);
        }
    }

    void OnTriggerExit(Collider other) {
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
        {
            entered = false;
        }
    }
}
