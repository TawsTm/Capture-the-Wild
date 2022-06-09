using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public FieldOfView fov;
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
        topViewCamera = !topViewCamera;

        if(!topViewCamera) {
            animator.Play("CarViewState");

            // Tell the CarCamera to start searching
            fov.setCamStatus(topViewCamera);
            fov.startSearch();
        }
        else {
            animator.Play("TopViewState");

            fov.setCamStatus(topViewCamera);
        }
    }
}
