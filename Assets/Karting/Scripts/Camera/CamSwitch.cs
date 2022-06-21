using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{

    Camera m_MainCamera;
    public LayerMask _carCamMask;
    public LayerMask _topViewMask;

    public FieldOfView fov;
    public bool topViewCamera = true;

    private Animator animator;

    void Start() {
        m_MainCamera = FindObjectOfType<Camera>();
		DebugUtility.HandleErrorIfNullFindObject<Camera, CamSwitch>(m_MainCamera, this);
    }

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

            // Tell the Main Camera which Culling Mask to use
            m_MainCamera.cullingMask = _carCamMask;
        }
        else {
            animator.Play("TopViewState");

            fov.setCamStatus(topViewCamera);

            // Tell the Main Camera which Culling Mask to use
            m_MainCamera.cullingMask = _topViewMask;
        }
    }
}
