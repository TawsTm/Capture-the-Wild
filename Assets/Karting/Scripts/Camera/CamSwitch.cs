using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public bool topViewCamera = true;

    private Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        if(topViewCamera) {
            animator.Play("CarViewState");
        }
        else {
            animator.Play("TopViewState");
        }
        topViewCamera = !topViewCamera;
    }
}
