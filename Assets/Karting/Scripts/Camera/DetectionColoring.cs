using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionColoring : MonoBehaviour
{
    public Image crosshair;
    // Start is called before the first frame update
    void Start()
    {
        crosshair.color = new Color(0.5f,0.1f,0.1f,1);
    }

    public void SetActive(bool _on) {
        if(_on) {
            //Debug.Log("Ich sollte färben");
            crosshair.color = new Color(0.1f,0.5f,0.1f,1);
        } else {
            crosshair.color = new Color(0.5f,0.1f,0.1f,1);
        }
    }
}
