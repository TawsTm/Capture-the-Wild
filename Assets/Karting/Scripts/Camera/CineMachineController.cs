using UnityEngine;
using UnityEngine.InputSystem;

public class CineMachineController : MonoBehaviour
{

    private PlayerInput playerInput;

    // Store our controls
    private InputAction switchAction;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        switchAction = playerInput.actions["Switch"];
        switchAction.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
