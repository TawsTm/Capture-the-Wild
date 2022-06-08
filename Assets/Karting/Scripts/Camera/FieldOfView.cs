using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    /** Camera Movement **/
    public CamSwitch CamStatus;
    private bool newCamStatus;

    [Range(0.1f, 20.0f), Tooltip("Used to control the speed of the camera when filming")]
        public float CameraSpeed = 0.3f;

    // the input sources that can control the kart
    private float turnInput = 0;

    /** FOV **/
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    void Start() {
        newCamStatus = CamStatus.topViewCamera;
        // Sets how often the Vieww is checked for Targets
        StartCoroutine("FindTargetsWithDelay", 3f);
    }

    IEnumerator FindTargetsWithDelay(float delay) {
        while (!CamStatus.topViewCamera) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i = 0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                float dstToTarget = Vector3.Distance (transform.position, target.position);

                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                    // What should happen if a Target is in view
                    visibleTargets.Add(target);
                    Debug.Log(targetsInViewRadius[i].name);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if(!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void Update()
    {
        if(!CamStatus.topViewCamera) {
            turnInput = Input.GetAxis("Horizontal");
            transform.Rotate(0, turnInput*CameraSpeed, 0, Space.Self);
            if(!CamStatus.topViewCamera && newCamStatus != CamStatus.topViewCamera) {
                StartCoroutine("FindTargetsWithDelay", 3f);
                newCamStatus = CamStatus.topViewCamera;
            }
        } else {
            if(newCamStatus != CamStatus.topViewCamera) {
                newCamStatus = CamStatus.topViewCamera;
            }
        }
    }
}