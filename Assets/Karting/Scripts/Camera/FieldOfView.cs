using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // Time to check for Animal
    private float timeForAnimalCheck = .2f;

    /** Camera Movement **/
    public CamSwitch CamStatus;
    private bool newCamStatus;

    public float timeTillTargetFound = 3f;

    private bool statusCam = true;

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

    public List<Animal> visibleTargets = new List<Animal>();
    private List<Animal> visibleTargetsCopy = new List<Animal>();

    VideoManager m_VideoManager;
    DetectionColoring m_DetectionColoring;

    void Start() {

        m_DetectionColoring = FindObjectOfType<DetectionColoring>();
		DebugUtility.HandleErrorIfNullFindObject<DetectionColoring, FieldOfView>(m_DetectionColoring, this);

        m_VideoManager = FindObjectOfType<VideoManager>();
		DebugUtility.HandleErrorIfNullFindObject<VideoManager, FieldOfView>(m_VideoManager, this);

    }

    IEnumerator FindTargetsWithDelay(float delay) {
        while (!statusCam) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() {
        visibleTargets.Clear();
        visibleTargetsCopy.ForEach((item) =>
        {
            visibleTargets.Add(item);
        });
        visibleTargetsCopy.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i = 0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                float dstToTarget = Vector3.Distance (transform.position, target.position);

                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                    Animal animal = targetsInViewRadius[i].GetComponent<Animal>();
                    // What should happen if a Target is in view
                    bool found = false;
                    for(int j = 0; j < visibleTargets.Count; j++) {
                        if(visibleTargets[j] == animal && AnimalManager.hasMember(animal)){
                            found = true;

                            animal.ScreenTime += timeForAnimalCheck;
                            if(animal.ScreenTime > timeTillTargetFound) {
                                AnimalManager.RemoveAnimal(animal);
                                m_VideoManager.PlayVideo(animal.Name);
                            } else {
                                //Debug.Log(animal.Name + ". " + animal.ScreenTime);
                                visibleTargetsCopy.Add(animal);
                            }
                            break;
                        }
                    }
                    // The first frame where the animal is seen
                    if (!found && AnimalManager.hasMember(animal)) {
                        visibleTargetsCopy.Add(animal);
                        animal.ScreenTime = 0;
                        //Debug.Log("First seen: " + animal.Name);
                    }
                }
            }
        }
        // Color the CarCamera Canvas for vidual Feedback if there are possible Animals in Range
        if(visibleTargetsCopy.Count != 0) {
            m_DetectionColoring.SetActive(true);
        } else {
            m_DetectionColoring.SetActive(false);
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
        if(!statusCam) {
            turnInput = Input.GetAxis("Horizontal");
            transform.Rotate(0, turnInput*CameraSpeed, 0, Space.Self);
        }
    }

    public void startSearch() {
        // Targets are reset on every Search Start, so that you need to film x seconds in one go
        visibleTargets.Clear();
        visibleTargetsCopy.Clear();
        StartCoroutine("FindTargetsWithDelay", timeForAnimalCheck);
    }

    public void setCamStatus(bool _state) {
        statusCam = _state;
        //Debug.Log("Ich habe geswitched");
    }
}
