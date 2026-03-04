using UnityEngine;
using UnityEngine.InputSystem;

public class Movement: MonoBehaviour
{   
    void OnEnable()  => moveAction.action.Enable();
    void OnDisable() => moveAction.action.Disable();
    public Transform LeftController;
    public Transform ThumbStick;
    public InputActionReference moveAction;
    public GameObject XRorigin;

    public float movementSpeed = 1f;
    void Update()
    {   
        Vector2 JoystickDirection = moveAction.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3();
        direction += LeftController.right;
        direction += LeftController.forward;
        if (direction.sqrMagnitude > 1e-6f)
        direction.Normalize();
        Debug.Log(direction);
        Debug.Log(JoystickDirection);
        // move = direction * 

    }
}
