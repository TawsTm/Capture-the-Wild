using System.Collections;
using UnityEngine;

public class DisplayTutorialMessage : MonoBehaviour
{
    [Tooltip("The text that will be displayed")]
    [TextArea]
    public string message;
    [Tooltip("Prefab for the message")]
    public PoolObjectDef messagePrefab;
    [Tooltip("Delay before displaying the message")]
    public float delayBeforeShowing;
    [Tooltip("Time until the Object is destroyed")]
    public float timeBeforeDestroy = 5f;

    [Tooltip("Sound played when receiving damages")]
    public AudioClip CollectSound;
    [Tooltip("Layers to trigger with")]
    public LayerMask layerMask;
    
    float m_InitTime = float.NegativeInfinity;

    public bool autoDisplayOnAwake;
    bool m_WasDisplayed;
    DisplayMessageManager m_DisplayMessageManager;

    private NotificationToast notification;

    void OnEnable()
    {
        m_InitTime = Time.time;
        if (m_DisplayMessageManager == null)
            m_DisplayMessageManager = FindObjectOfType<DisplayMessageManager>();
        
        DebugUtility.HandleErrorIfNullFindObject<DisplayMessageManager, DisplayMessage>(m_DisplayMessageManager, this);


        m_WasDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoDisplayOnAwake) return;
        if (m_WasDisplayed) return;
        

        if (Time.time - m_InitTime > delayBeforeShowing) Display();
        
    }
    
    public void Display()
    {
        notification = messagePrefab.getObject(true,m_DisplayMessageManager.DisplayMessageRect.transform).GetComponent<NotificationToast>();
        
        notification.Initialize(message);
        
        m_DisplayMessageManager.DisplayMessageRect.UpdateTable(notification.gameObject);

        m_WasDisplayed = true;

        if (CollectSound)
        {
            AudioUtility.CreateSFX(CollectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        StartCoroutine(messagePrefab.ReturnWithDelay(notification.gameObject,notification.TotalRunTime));

        Destroy(gameObject, timeBeforeDestroy);

    }

    void OnTriggerEnter(Collider other) {
        if(!m_WasDisplayed) {
            if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
            {
                Display();
            }
        }
    }

   
}
