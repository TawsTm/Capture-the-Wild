using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionColoring : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.color = new Color(0,0,0,1);
    }

    public void SetActive(bool _on) {
        if(_on) {
            Debug.Log("Ich sollte färben");
            text.color = new Color(0.5f,0,0,1);
        } else {
            text.color = new Color(1,1,1,1);
        }
    }
}
